using Xamarin.Forms;
using System.ServiceModel.Channels;
using ModernDirectory.ViewModels;
using ModernDirectory.Models;
using ModernDirectory.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ModernDirectory.Utilities.Codes;

namespace ModernDirectory.Pages
{
	public partial class DirectoryPage : ContentPage
	{
		public DirectoryPage ()
		{
			InitializeComponent ();
			BindingContext = new DirectoryViewModel (new DirectoryService ());
			Device.OnPlatform (Android: () =>
				NavigationPage.SetHasNavigationBar (this, false));
		}

	
		private async void Listview_ItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;

			await Navigation.PushAsync (new DirectoryDetailPage (e.SelectedItem as Person));

			peopleListview.SelectedItem = null;
		}

		ObservableCollection<Person> _originalSource;

		/// <summary>
		/// This is a temp implementation, make a server call when fully implemented
		/// Source From https://blog.verslu.is/xamarin/finding-nemo-implementing-xamarin-forms-searchbar/
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private async void SearchBar_OnTextChanged (object sender, TextChangedEventArgs e)
		{
			//todo : implement using server call
			var people = peopleListview.ItemsSource as ObservableCollection<Person>;

			if (people != null) {
				if (_originalSource == null)
					_originalSource = people;
				
				peopleListview.IsRefreshing = true;

				//Simulate long server call
				await Task.Delay (TimeSpan.FromSeconds (2)).ContinueWith ((r) => {

//					Device.BeginInvokeOnMainThread (() =>
//						{
//							if (string.IsNullOrWhiteSpace(e.NewTextValue))
//								peopleListview.ItemsSource = _originalSource;
//							else
//								peopleListview.ItemsSource = new ObservableCollection<Person>(_originalSource.Where(p => p.FullName.ToLower ().Contains(e.NewTextValue.ToLower ()) 
//									|| p.PhoneNumber.Contains (e.NewTextValue)));
//
//							peopleListview.IsRefreshing = false;
//						});
				});
			
			}
		}
	}
}

