using System;
using Xamarin.Forms;
using ModernDirectory.Services;
using System.Diagnostics;
using ModernDirectory.Utilities.Codes;

namespace ModernDirectory.Pages
{
	public class OAuthLoginPage : ContentPage
	{
		public OAuthLoginPage ()
		{
			//TOdo : add back when the dep service works
			_authService = DependencyService.Get<IOAuthService> ();

			const string clientId = "872010536308-7bl5lrkkjnghag6gt70uvaegj3cgn0h4.apps.googleusercontent.com";
			const string clientSecret = "fscVN3S_0Zbs4P-NJom1B_Lp";
			const string scope = "https://www.googleapis.com/auth/plus.login";
			var authorizeUrl =  new Uri ("https://accounts.google.com/o/oauth2/auth");
//			var redirectUrl= new Uri ("urn:ietf:wg:oauth:2.0:oob");
			var redirectUrl= new Uri ("https://github.com/paulpatarinski/ModernDirectory/blob/master/Screenshots/ModernDirectory_1.png");
			var accessTokenUrl =  new Uri ("https://accounts.google.com/o/oauth2/token");

			_authService.Initialize (clientId, clientSecret, scope, authorizeUrl, redirectUrl, accessTokenUrl);

			_authService.Completed += AuthCompleted;

		}

		readonly IOAuthService _authService;

		async void AuthCompleted (object sender, OAuthCompletedEventArgs e)
		{
			if(e.IsAuthenticated)
			{
				Debug.WriteLine ("Successfully authenticated");

				AppProperties.GooglePlusAccessToken = e.AccessToken;
			
				await Navigation.PushAsync (new DirectoryPage()).ContinueWith ((r) =>{
					Device.BeginInvokeOnMainThread(() => {
						Navigation.RemovePage (this);
					});
				});
			}
			else{
				Debug.WriteLine ("User cancelled");
			}
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if(string.IsNullOrWhiteSpace(AppProperties.GooglePlusAccessToken))
				_authService.ShowUI (this);
		}
	}
}