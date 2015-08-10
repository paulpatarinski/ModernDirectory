using Xamarin.Forms;
using System.ServiceModel.Channels;
using ModernDirectory.ViewModels;
using ModernDirectory.Models;

namespace ModernDirectory.Pages
{
	public partial class DirectoryPage : ContentPage
	{
		public DirectoryPage ()
		{
			InitializeComponent ();
			BindingContext = new DirectoryViewModel ();
		}

		private async void Listview_ItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;

			await Navigation.PushAsync (new DirectoryDetailPage(e.SelectedItem as Person));

			peopleListview.SelectedItem = null;
		}
	}
}

