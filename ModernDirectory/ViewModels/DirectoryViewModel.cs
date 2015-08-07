using PropertyChanged;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using ModernDirectory.Models;

namespace ModernDirectory.ViewModels
{
	[ImplementPropertyChanged]
	public class DirectoryViewModel
	{
		public DirectoryViewModel ()
		{
			SampleText = "Loading...";
			People = new ObservableCollection<Person> ();

			Task.Delay (TimeSpan.FromSeconds (2)).ContinueWith ((r) => {
				for (int i = 0; i < 10; i++) {
					People.Add (new Person{FirstName = "John", LastName = "Doe"});
				}
			});
		}

		public string SampleText {
			get;
			set;
		}

		public ObservableCollection<Person> People {
			get;
			set;
		}
	}
}