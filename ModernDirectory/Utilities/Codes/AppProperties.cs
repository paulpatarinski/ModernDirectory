using System;
using Xamarin.Forms;

namespace ModernDirectory.Utilities.Codes
{
	public static class AppProperties
	{
		public static string GooglePlusAccessToken{get{
				object key;

				Application.Current.Properties.TryGetValue ("googlePlusAccessToken", out key);

				return key == null ? string.Empty : key.ToString ();
			}
			set{

				if(Application.Current.Properties.ContainsKey ("googlePlusAccessToken"))
				{
					Application.Current.Properties ["googlePlusAccessToken"] = value;
				}
				else{
					Application.Current.Properties.Add ("googlePlusAccessToken", value);
				}
			}}
	}
}

