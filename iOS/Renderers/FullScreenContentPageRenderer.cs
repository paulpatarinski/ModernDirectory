using System;
using Xamarin.Forms;
using ModernDirectory.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using ModernDirectory.CustomControls;

[assembly:ExportRenderer (typeof(ContentPage), typeof(CustomContentPageRenderer))]
namespace ModernDirectory.iOS.Renderers
{
	public class CustomContentPageRenderer : PageRenderer
	{
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		
			if (NavigationController != null) {
				NavigationController.NavigationBar.ShadowImage = new UIImage ();
				NavigationController.NavigationBar.SetBackgroundImage (new UIImage (), UIBarMetrics.Default);
			}
		}
	}
}

