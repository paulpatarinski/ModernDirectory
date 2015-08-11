using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModernDirectory.Models;
using System.Threading;

namespace ModernDirectory.Services
{
	public class DirectoryService : IDirectoryService
	{
		private const int SERVER_CALL_DELAY_IN_SEC = 2;

		public async Task<IEnumerable<Person>> GetPeopleAsync(PagedDataQuery query)
		{
			var result = new List<Person> ();

			//Simulate server call
			await Task.Delay (TimeSpan.FromSeconds (SERVER_CALL_DELAY_IN_SEC)).ContinueWith ((r) => {
				for (int i = 0; i < query.PageSize; i++) {
					if(i % 2 == 0)
					{
						result.Add (new Person{FirstName = "John", LastName = "Doe", PhoneNumber = String.Format ("(773) 782-234{0}", i % 10)});
					}
					else{
						result.Add (new Person{FirstName = "Jane", LastName = "Doe", PhoneNumber = String.Format ("(224) 323-234{0}", i % 10)});
					}
				}	
			});

			return result;
		}
	}
}

