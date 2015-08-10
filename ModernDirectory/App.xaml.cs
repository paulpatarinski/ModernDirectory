using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ModernDirectory.Pages;

namespace ModernDirectory
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();
			// The root page of your application
			MainPage = new DirectoryPage ();
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

