using PropertyChanged;
using System.Collections.ObjectModel;
using ModernDirectory.Models;
using System;
using System.Threading.Tasks;

namespace ModernDirectory.ViewModels
{
	[ImplementPropertyChanged]
	public class DirectoryViewModel
	{
		public DirectoryViewModel ()
		{
			SampleText = "Loading...";
			People = new ObservableCollection<Person> ();
			LoadDirectoryItemsAsync ();
		}

		public string SampleText {
			get;
			set;
		}

		public ObservableCollection<Person> People {
			get;
			set;
		}


		private async Task LoadDirectoryItemsAsync()
		{
			//todo Replace with service call
			await Task.Run (() => {
				for (int i = 0; i < 100; i++) {
					People.Add (new Person{FirstName = "John", LastName = "Doe", PhoneNumber = String.Format ("(773) 782-234{0}", i % 10)});
				}		
			});
		}
	}
}