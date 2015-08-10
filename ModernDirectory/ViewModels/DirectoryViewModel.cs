using PropertyChanged;
using System.Collections.ObjectModel;
using ModernDirectory.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace ModernDirectory.ViewModels
{
	[ImplementPropertyChanged]
	public class DirectoryViewModel
	{
		public DirectoryViewModel ()
		{
			SampleText = "Loading...";
			People = new ObservableCollection<Person> ();
		}

		public string SampleText {
			get;
			set;
		}

		public ObservableCollection<Person> People {
			get;
			set;
		}

		public ICommand LoadMore
		{
			get
			{
				return new Command<PagedDataQuery>(async query =>
				await LoadMoreExecute (query));
			}
		}

		private async Task LoadMoreExecute(PagedDataQuery query)
		{
			await Task.Run (() => {
				Device.BeginInvokeOnMainThread (() => {
					for (int i = 0; i < query.PageSize; i++) {
						People.Add (new Person{FirstName = "John", LastName = "Doe", PhoneNumber = String.Format ("(773) 782-234{0}", i % 10)});
					}	
				});
			});
		}
	}
}