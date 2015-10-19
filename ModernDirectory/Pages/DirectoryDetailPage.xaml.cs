
using Xamarin.Forms;
using ModernDirectory.Models;
using ModernDirectory.ViewModels;
using ModernDirectory.CustomControls;

namespace ModernDirectory.Pages
{
	public partial class DirectoryDetailPage : FullScreenContentPage
	{
		public DirectoryDetailPage (Person person)
		{
			InitializeComponent ();
			BindingContext = new DirectoryDetailViewModel (person);
		}
	}
}