using System;
using Xamarin.Forms;
using ModernDirectory.Services;
using System.Diagnostics;
using ModernDirectory.Utilities.Codes;
using System.Linq;

namespace ModernDirectory.Pages
{
	public class OAuthLoginPage : ContentPage
	{
		IOAuthService _authService;

		async void AuthCompleted (object sender, OAuthCompletedEventArgs e)
		{
			if (e.IsAuthenticated) {
				Debug.WriteLine ("Successfully authenticated");

				var googleAccounts = _authService.GetServiceAccounts (OAuthServiceType.GooglePlay);

				AppProperties.GooglePlusAccounts = googleAccounts;
			
				await Navigation.PushAsync (new DirectoryPage ()).ContinueWith ((r) => {
					Device.BeginInvokeOnMainThread (() => {
						Navigation.RemovePage (this);
					});
				});
			} else {
				Debug.WriteLine ("User cancelled");
			}
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			_authService = DependencyService.Get<IOAuthService> ();

			const string clientId = "872010536308-7bl5lrkkjnghag6gt70uvaegj3cgn0h4.apps.googleusercontent.com";
			const string clientSecret = "fscVN3S_0Zbs4P-NJom1B_Lp";
			const string scope = "https://www.googleapis.com/auth/plus.login";
			var authorizeUrl = new Uri ("https://accounts.google.com/o/oauth2/auth");
			var redirectUrl = new Uri ("https://github.com/paulpatarinski/ModernDirectory/blob/master/Screenshots/ModernDirectory_1.png");
			var accessTokenUrl = new Uri ("https://accounts.google.com/o/oauth2/token");

			_authService.Initialize (clientId, clientSecret, scope, authorizeUrl, redirectUrl, accessTokenUrl, this, OAuthServiceType.GooglePlay);

			_authService.Completed += AuthCompleted;

			if (AppProperties.GooglePlusAccounts == null)
				_authService.ShowUI (this);
		}
	}
}