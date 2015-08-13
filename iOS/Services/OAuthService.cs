using System;
using ModernDirectory.Services;
using Xamarin.Auth;
using UIKit;
using ModernDirectory.iOS.Services;
using Xamarin.Forms;
using ModernDirectory.iOS.ExtensionsMethods;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.Dependency (typeof (OAuthService))]
namespace ModernDirectory.iOS.Services
{
	public class OAuthService : IOAuthService
	{
		OAuth2Authenticator _authenticator;

		public event EventHandler<OAuthCompletedEventArgs> Completed;

		public void Initialize(string clientId,string clientSecret, string scope, Uri authorizeUri, Uri redirectUri, Uri accessTokenUri)
		{
			_authenticator = new OAuth2Authenticator (clientId, clientSecret, scope, authorizeUri, redirectUri,accessTokenUri);

			_authenticator.Completed += (sender, eventArgs) => {
				var renderer = (PageRenderer)_loginPage.GetRenderer ();

				renderer.DismissViewController (true,null);

				var accessToken = "";

				if(eventArgs.Account != null && eventArgs.Account.Properties != null)
				{
					eventArgs.Account.Properties.TryGetValue("access_token",out accessToken);
				}

				Completed.Invoke (this, new OAuthCompletedEventArgs(eventArgs.IsAuthenticated, accessToken));
			};
		}

		Page _loginPage;

		public void ShowUI(Page loginPage)
		{
			_loginPage = loginPage;
			var renderer = (PageRenderer)loginPage.GetRenderer ();

			var authViewControler =  _authenticator.GetUI ();
			renderer.PresentViewController (authViewControler, true, null);
		}
	}
}