using Xamarin.Forms;
using System.ServiceModel.Channels;
using ModernDirectory.ViewModels;

namespace ModernDirectory.Pages
{
	public partial class DirectoryPage : ContentPage
	{
		public DirectoryPage ()
		{
			InitializeComponent ();
			BindingContext = new DirectoryViewModel ();
		}
	}
}

