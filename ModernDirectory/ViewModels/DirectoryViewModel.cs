using PropertyChanged;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;

namespace ModernDirectory.ViewModels
{
	[ImplementPropertyChanged]
	public class DirectoryViewModel
	{
		public DirectoryViewModel ()
		{
			SampleText = "Loading...";
			
			Task.Delay (TimeSpan.FromSeconds (2)).ContinueWith ((r) => {
				SampleText = "John Doe";
			});
		}

		public string SampleText {
			get;
			set;
		}


	}
}