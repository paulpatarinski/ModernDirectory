
using Android.App;
using Android.Content.PM;
using Android.OS;
using RoundedBoxView.Forms.Plugin.Droid;
using ImageCircle.Forms.Plugin.Droid;

namespace ModernDirectory.Droid
{
	[Activity (Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			RoundedBoxViewRenderer.Init ();
			ImageCircleRenderer.Init ();

			LoadApplication (new App ());
		}
	}
}

