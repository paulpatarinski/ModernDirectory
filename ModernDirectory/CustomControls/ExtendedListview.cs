using System;
using Xamarin.Forms;
using ModernDirectory.Models;
using System.Collections;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ModernDirectory.CustomControls
{
	public class ExtendedListview : ListView
	{
		public ExtendedListview()
		{
			ItemAppearing += ExtendedListview_ItemAppearing;
		}

		/// <summary>
		/// Command that gets executed when more data needs to be loaded, based on Offset
		/// LoadMaorDotsQuery will have the PageNumber and PageSize
		/// </summary>
		public static readonly BindableProperty LoadMoreCommandProperty =
			BindableProperty.Create("LoadMoreCommand", typeof(Command<PagedDataQuery>), typeof(ExtendedListview),
				default(Command<PagedDataQuery>));

		/// <summary>
		/// Offset from ItemSource.Count before LoadMore Command is executed The default value is 7.
		/// </summary>
		public static readonly BindableProperty OffsetProperty =
			BindableProperty.Create("Offset", typeof(int), typeof(ExtendedListview), DEFAULT_OFFSET);

		/// <summary>
		/// The number of records that are displayed for each page of data. The default is 10.
		/// </summary>
		public static readonly BindableProperty PageSizeProperty =
			BindableProperty.Create("PageSize", typeof(int), typeof(ExtendedListview), DEFAULT_PAGE_SIZE);

		private const int DEFAULT_OFFSET = 7;
		private const int DEFAULT_PAGE_SIZE = 10;

		private bool isLoading;

		/// <summary>
		/// Command that gets executed when more data needs to be loaded, based on Offset
		/// LoadMaorDotsQuery will have the PageNumber and PageSize WinPhone : LoadMore command will get
		/// called multiple times initially to Preload Data
		/// </summary>
		public Command<PagedDataQuery> LoadMoreCommand
		{
			get { return (Command<PagedDataQuery>)GetValue(LoadMoreCommandProperty); }
			set { SetValue(LoadMoreCommandProperty, value); }
		}

		/// <summary>
		/// Offset from ItemSource.Count before LoadMore Command is executed
		/// </summary>
		public int Offset
		{
			get { return (int)GetValue(OffsetProperty); }
			set { SetValue(OffsetProperty, value); }
		}

		/// <summary>
		/// The current page number.
		/// </summary>
		public int PageNumber { get; set; }

		/// <summary>
		/// The number of records that are displayed for each page of data. The default is 10.
		/// </summary>
		public int PageSize
		{
			get { return (int)GetValue(PageSizeProperty); }
			set { SetValue(PageSizeProperty, value); }
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			var items = ItemsSource as IList;

			if(items == null) return;

			if(!LoadMoreCommand.CanExecute(null)) return;

			LoadMore();
		}

		protected override void OnPropertyChanged (string propertyName)
		{
			base.OnPropertyChanged (propertyName);

			if(propertyName.Equals (IsPullToRefreshEnabledProperty.PropertyName))
			{
				if(IsPullToRefreshEnabled)
				{
					RefreshCommand = new Command (async () => await ExecuteRefresh (), () => !IsRefreshing); 
				}
			}
		}


		public void ExtendedListview_ItemAppearing (object sender, ItemVisibilityEventArgs e)
		{
			var items = ItemsSource as IList;

			if(items == null) return;

			var currentItemIndex = items.IndexOf(e.Item);

			if(currentItemIndex >= (PageNumber * PageSize - Offset) && LoadMoreCommand.CanExecute(null))
				LoadMore();
		}

		private async Task ExecuteRefresh()
		{
			var items = ItemsSource as IList;

			if(items == null) return;

			items.Clear ();

			PageNumber = 0;

			OnBindingContextChanged ();
		}

		private void LoadMore()
		{
			PageNumber++;

			LoadMoreCommand.Execute(new PagedDataQuery { PageNumber = PageNumber, PageSize = PageSize });
		}
	}
}

