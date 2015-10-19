using System;
using Xamarin.Forms;
using ModernDirectory.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using ModernDirectory.CustomControls;

[assembly:ExportRenderer (typeof(FullScreenContentPage), typeof(FullScreenContentPageRenderer))]
namespace ModernDirectory.iOS.Renderers
{
	public class FullScreenContentPageRenderer : PageRenderer
	{
		bool _initialNavBarTranslucent;
		UIImage _initialNavBarBackgroundImage;
		UIImage _initialNavBarShadowImage;

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			if (NavigationController != null) {

				MakeNavBarTranslucent ();

				var page = Element as Page;

				if (page != null) {
					page.Padding = new Thickness (0, 20, 0, 0);
				}
			}
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);

			if (NavigationController != null) {
				RestoreNavBarInitialState ();
			}
		}


		void MakeNavBarTranslucent ()
		{
			_initialNavBarTranslucent = NavigationController.NavigationBar.Translucent;
			NavigationController.NavigationBar.Translucent = true;
			_initialNavBarBackgroundImage = NavigationController.NavigationBar.GetBackgroundImage (UIBarMetrics.Default);
			NavigationController.NavigationBar.SetBackgroundImage (new UIImage (), UIBarMetrics.Default);
			_initialNavBarShadowImage = NavigationController.NavigationBar.ShadowImage;
			NavigationController.NavigationBar.ShadowImage = new UIImage ();
		}

		void RestoreNavBarInitialState ()
		{
			NavigationController.NavigationBar.Translucent = _initialNavBarTranslucent;
			NavigationController.NavigationBar.SetBackgroundImage (_initialNavBarBackgroundImage, UIBarMetrics.Default);
			NavigationController.NavigationBar.ShadowImage = _initialNavBarShadowImage;
		}
	}
}

