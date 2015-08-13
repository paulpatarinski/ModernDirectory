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

			const string clientId = "77209vuoijv1f4";
			const string clientSecret = "cW7qN5MZFNot1GlY";
			const string scope = "r_basicprofile";
			var authorizeUrl =  new Uri ("https://www.linkedin.com/uas/oauth2/authorization");
			var redirectUrl= new Uri ("https://github.com/paulpatarinski/ModernDirectory/blob/master/Screenshots/ModernDirectory_1.png");
			var accessTokenUrl =  new Uri ("https://www.linkedin.com/uas/oauth2/accessToken");

			_authService.Initialize (clientId, clientSecret, scope, authorizeUrl, redirectUrl, accessTokenUrl);

			_authService.Completed += AuthCompleted;

		}

		readonly IOAuthService _authService;

		async void AuthCompleted (object sender, OAuthCompletedEventArgs e)
		{
			if(e.IsAuthenticated)
			{
				Debug.WriteLine ("Successfully authenticated");

				AppProperties.LinkedInAccessKey = e.AccessToken;
			
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

			if(string.IsNullOrWhiteSpace(AppProperties.LinkedInAccessKey))
				_authService.ShowUI (this);
		}
	}
}