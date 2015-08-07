using PropertyChanged;
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

			for (int i = 0; i < 100; i++) {
				People.Add (new Person{FirstName = "John", LastName = "Doe"});
			}
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