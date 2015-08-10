
using Xamarin.Forms;
using ModernDirectory.Models;
using ModernDirectory.ViewModels;

namespace ModernDirectory.Pages
{
	public partial class DirectoryDetailPage : ContentPage
	{
		public DirectoryDetailPage (Person person)
		{
			InitializeComponent ();
			BindingContext = new DirectoryDetailViewModel (person);
		}
	}
}