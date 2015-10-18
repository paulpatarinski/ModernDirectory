using System;
using Xamarin.Forms;
using System.Collections;
using ModernDirectory.Models;
using ModernDirectory.Utilities.Codes;
using System.Collections.Generic;

namespace ModernDirectory.Services
{
	public interface IOAuthService
	{
		void Initialize (string clientId, string clientSecret, string scope, Uri authorizeUri, Uri redirectUri, Uri accessTokenUri, Page page, string accountType);

		void ShowUI (Page loginPage);

		event EventHandler<OAuthCompletedEventArgs> Completed;

		IEnumerable<OAuthAccount> GetServiceAccounts (string serviceType);
	}

	public class OAuthCompletedEventArgs : EventArgs
	{
		public OAuthCompletedEventArgs (bool isAuthenticated)
		{
			IsAuthenticated = isAuthenticated;
		}

		public bool IsAuthenticated {
			get;
			set;
		}
	}
}