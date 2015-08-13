using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModernDirectory.Models;
using Refit;
using System.Net.Http;
using ModernDirectory.Utilities.Codes;
using System.Diagnostics;
using Xamarin.Forms;

namespace ModernDirectory.Services
{
	public class DirectoryService : IDirectoryService
	{
		public DirectoryService ()
		{
			_googlePlusApi = RestService.For<IGooglePlusApi>(new HttpClient(new AuthenticatedHttpClientHandler(GetToken))
				{ BaseAddress = new Uri("https://www.googleapis.com/plus/v1") });
		}

		IGooglePlusApi _googlePlusApi;
		string _nextPageToken = string.Empty;

		public async Task<IEnumerable<Person>> GetPeopleAsync(PagedDataQuery query)
		{
			var result = new List<Person> ();

			try {
				var peoplePayload = await _googlePlusApi.GetPeopleAsync(query.PageSize, _nextPageToken);

				_nextPageToken = peoplePayload.nextPageToken == null ? string.Empty : peoplePayload.nextPageToken;

				result = peoplePayload.People;

			} catch (Exception ex) {
				//todo replace with proper error handling
				Debug.WriteLine (ex);
			}

			return result;
		}

		public async Task<IEnumerable<Person>> SearchPeopleAsync(PagedDataQuery query)
		{
			var result = new List<Person> ();

			try {
				var searchQuery = "fish";

				var peoplePayload = await _googlePlusApi.SearchPeopleAsync(searchQuery, query.PageSize,_nextPageToken);

				_nextPageToken = peoplePayload.nextPageToken;

				result = peoplePayload.People;

			} catch (Exception ex) {
				//todo replace with proper error handling
				Debug.WriteLine (ex);
			}

			return result;
		}

		private async Task<string> GetToken()
		{
			return await Task.FromResult<string> (AppProperties.GooglePlusAccessToken);
		}
	}
}

