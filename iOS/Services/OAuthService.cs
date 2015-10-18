using System;
using ModernDirectory.Services;
using Xamarin.Auth;
using UIKit;
using ModernDirectory.iOS.Services;
using Xamarin.Forms;
using ModernDirectory.iOS.ExtensionsMethods;
using Xamarin.Forms.Platform.iOS;
using System.Collections;
using ModernDirectory.Models;
using System.Collections.Generic;
using System.Linq;

[assembly: Xamarin.Forms.Dependency (typeof(OAuthService))]
namespace ModernDirectory.iOS.Services
{
	public class OAuthService : IOAuthService
	{
		OAuth2Authenticator _authenticator;

		public event EventHandler<OAuthCompletedEventArgs> Completed;

		public void Initialize (string clientId, string clientSecret, string scope, Uri authorizeUri, Uri redirectUri, Uri accessTokenUri, Page page, string serviceId)
		{
			_authenticator = new OAuth2Authenticator (clientId, clientSecret, scope, authorizeUri, redirectUri, accessTokenUri);

			_authenticator.Completed += (sender, eventArgs) => {
				var renderer = (PageRenderer)_loginPage.GetRenderer ();

				renderer.DismissViewController (true, null);

				if (eventArgs.Account != null) {
					AccountStore.Create ().Save (eventArgs.Account, serviceId);
				}

				Completed.Invoke (this, new OAuthCompletedEventArgs (eventArgs.IsAuthenticated));
			};
		}

		Page _loginPage;

		public void ShowUI (Page loginPage)
		{
			_loginPage = loginPage;
			var renderer = (PageRenderer)loginPage.GetRenderer ();

			var authViewControler = _authenticator.GetUI ();
			renderer.PresentViewController (authViewControler, true, null);
		}

		public IEnumerable<OAuthAccount> GetServiceAccounts (string serviceId)
		{
			IEnumerable<OAuthAccount> result = new List<OAuthAccount> ();

			var nativeAccounts = AccountStore.Create ().FindAccountsForService (serviceId);

			if (nativeAccounts != null) {
				result = nativeAccounts.Select (nativeAccount => nativeAccount.ToFormsModel ());
			}

			return result;
		}
	}
}