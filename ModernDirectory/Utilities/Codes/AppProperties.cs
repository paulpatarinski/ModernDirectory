using System;
using Xamarin.Forms;
using System.Collections;
using ModernDirectory.Services;
using System.Collections.Generic;
using ModernDirectory.Models;

namespace ModernDirectory.Utilities.Codes
{
	public static class AppProperties
	{
		public static string GooglePlusAccessToken {
			get {
				object key;

				Application.Current.Properties.TryGetValue ("googlePlusAccessToken", out key);

				return key == null ? string.Empty : key.ToString ();
			}
			set {

				if (Application.Current.Properties.ContainsKey ("googlePlusAccessToken")) {
					Application.Current.Properties ["googlePlusAccessToken"] = value;
				} else {
					Application.Current.Properties.Add ("googlePlusAccessToken", value);
				}
			}
		}

		public static IEnumerable<OAuthAccount> GooglePlusAccounts {
			get {
				object accounts;

				Application.Current.Properties.TryGetValue ("googlePlusAccounts", out accounts);

				return accounts as IEnumerable<OAuthAccount>;
			}
			set {

				if (Application.Current.Properties.ContainsKey ("googlePlusAccounts")) {
					Application.Current.Properties ["googlePlusAccounts"] = value;
				} else {
					Application.Current.Properties.Add ("googlePlusAccounts", value);
				}
			}
		}
	}
}

