using System;
using ModernDirectory.Services;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ModernDirectory.Droid.Services;
using Android.App;
using ModernDirectory.Droid.ExtensionsMethods;

[assembly: Xamarin.Forms.Dependency (typeof (OAuthService))]
namespace ModernDirectory.Droid.Services
{
		public class OAuthService : IOAuthService
		{
			OAuth2Authenticator _authenticator;

			public event EventHandler<OAuthCompletedEventArgs> Completed;

			public void Initialize(string clientId,string clientSecret, string scope, Uri authorizeUri, Uri redirectUri, Uri accessTokenUri)
			{
				_authenticator = new OAuth2Authenticator (clientId, clientSecret, scope, authorizeUri, redirectUri,accessTokenUri);

				_authenticator.Completed += (sender, eventArgs) => {
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
			var renderer = (PageRenderer)loginPage.GetRenderer ();
				var activity = renderer.Context as Activity;
				activity.StartActivity (_authenticator.GetUI(activity));
			}
		}
}

