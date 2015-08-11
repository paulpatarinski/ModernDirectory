using PropertyChanged;
using System.Collections.ObjectModel;
using ModernDirectory.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using ModernDirectory.Services;

namespace ModernDirectory.ViewModels
{
	[ImplementPropertyChanged]
	public class DirectoryViewModel
	{ 
		public DirectoryViewModel (IDirectoryService directoryService)
		{
			_directoryService = directoryService;
			IsRefreshing = true;
			People = new ObservableCollection<Person> ();
		}

		private IDirectoryService _directoryService;

		public ObservableCollection<Person> People {
			get;
			set;
		}

		public bool IsBusy {
			get;
			set;
		}

		public bool IsRefreshing {
			get;
			set;
		}

		public ICommand LoadMore
		{
			get
			{
				return new Command<PagedDataQuery>(async query =>
					await LoadMoreExecute (query)
					, query => !IsBusy);
			}
		}


		private async Task LoadMoreExecute(PagedDataQuery query)
		{
			if(query.PageNumber == 1)
			{
				IsRefreshing = true;
			}
			else{
				IsBusy = true;
			}

			var people = await _directoryService.GetPeopleAsync (query);

			foreach(var person in people)
			{
				People.Add (person);
			}

			if(query.PageNumber == 1)
			{
				IsRefreshing = false;
			}
			else{
				IsBusy = false;
			}

		}
	}
}