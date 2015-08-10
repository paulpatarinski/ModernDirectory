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

		public bool IsBusy {
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

		private const int SERVER_CALL_DELAY_IN_SEC = 1;

		private async Task LoadMoreExecute(PagedDataQuery query)
		{
			IsBusy = true;

			//Simulate server call
			await Task.Delay (TimeSpan.FromSeconds (SERVER_CALL_DELAY_IN_SEC)).ContinueWith ((r) => {
				Device.BeginInvokeOnMainThread (() => {
					IsBusy = false;
					for (int i = 0; i < query.PageSize; i++) {
						People.Add (new Person{FirstName = "John", LastName = "Doe", PhoneNumber = String.Format ("(773) 782-234{0}", i % 10)});
					}	
				});
			});
		}
	}
}