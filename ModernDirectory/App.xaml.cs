using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ModernDirectory.Pages;

namespace ModernDirectory
{
	public partial class App : Application
	{
		private static NavigationPage _navPage;

		public App ()
		{
			InitializeComponent ();

			// The root page of your application
			_navPage = new NavigationPage (new DirectoryPage ()) {
				BarBackgroundColor = Color.FromHex ("#3F51B5"),
				BarTextColor = Color.White
			};
			MainPage = _navPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

