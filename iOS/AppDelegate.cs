using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using RoundedBoxView.Forms.Plugin.iOSUnified;
using ImageCircle.Forms.Plugin.iOS;

namespace ModernDirectory.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
			RoundedBoxViewRenderer.Init ();
			ImageCircleRenderer.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start ();
			#endif

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}


	
	}
}

