using System;
using Xamarin.Forms;

namespace ModernDirectory.Services
{
	public interface IOAuthService
	{
		void Initialize (string clientId, string clientSecret, string scope, Uri authorizeUri, Uri redirectUri, Uri accessTokenUri);
		void ShowUI(Page loginPage);
		event EventHandler<OAuthCompletedEventArgs> Completed;
	}

	public class OAuthCompletedEventArgs : EventArgs
	{
		public OAuthCompletedEventArgs (bool isAuthenticated, string accessToken)
		{
			IsAuthenticated = isAuthenticated;
			AccessToken = accessToken;
		}

		public bool IsAuthenticated {
			get;
			set;
		}

		public string AccessToken { get; set;}

	}
}