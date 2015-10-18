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
		}

		public async Task<IEnumerable<Person>> GetPeopleAsync (PagedDataQuery query)
		{
			var result = new List<Person> ();

			try {

				for (int i = 0; i < 10; i++) {
					result.Add (new Person {
						DisplayName = string.Format ("John Doe {0}", i)
					});
				}

			} catch (Exception ex) {
				//todo replace with proper error handling
				Debug.WriteLine (ex);
			}

			return result;
		}

		public async Task<IEnumerable<Person>> SearchPeopleAsync (PagedDataQuery query)
		{
			var result = new List<Person> ();

			try {
				var searchQuery = "fish";

//				var peoplePayload = await _googlePlusApi.SearchPeopleAsync(searchQuery, query.PageSize,_nextPageToken);
//
//				_nextPageToken = peoplePayload.nextPageToken;
//
//				result = peoplePayload.People;

			} catch (Exception ex) {
				//todo replace with proper error handling
				Debug.WriteLine (ex);
			}

			return result;
		}
	}
}

