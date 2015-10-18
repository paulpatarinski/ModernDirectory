using System;
using ModernDirectory.Services;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ModernDirectory.Droid.Services;
using Android.App;
using ModernDirectory.Droid.ExtensionsMethods;
using System.Collections.Generic;
using ModernDirectory.Models;

[assembly: Xamarin.Forms.Dependency (typeof(OAuthService))]
namespace ModernDirectory.Droid.Services
{
	public class OAuthService : ModernDirectory.Services.IOAuthService
	{
		OAuth2Authenticator _authenticator;

		public event EventHandler<OAuthCompletedEventArgs> Completed;

		Activity _currentContext;

		public void Initialize (string clientId, string clientSecret, string scope, Uri authorizeUri, Uri redirectUri, Uri accessTokenUri, Page currentPage, string serviceId)
		{
			var renderer = (PageRenderer)currentPage.GetRenderer ();
			_currentContext = renderer.Context as Activity;

			_authenticator = new OAuth2Authenticator (clientId, clientSecret, scope, authorizeUri, redirectUri, accessTokenUri);

			_authenticator.Completed += (sender, eventArgs) => {
				if (eventArgs.Account != null) {
					AccountStore.Create (currentContext).Save (eventArgs.Account, serviceId);
				}

				Completed.Invoke (this, new OAuthCompletedEventArgs (eventArgs.IsAuthenticated));
			};
		}

		Page _loginPage;

		public void ShowUI (Page loginPage)
		{
			_currentContext.StartActivity (_authenticator.GetUI (activity));
		}

		public IEnumerable<OAuthAccount> GetServiceAccounts (string serviceId, )
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

