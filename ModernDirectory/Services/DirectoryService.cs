using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModernDirectory.Models;
using Refit;
using System.Net.Http;
using ModernDirectory.Utilities.Codes;
using System.Diagnostics;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using System.Linq;
using ModernDirectory.Utilities.ExtensionsMethods;

namespace ModernDirectory.Services
{
	public class DirectoryService : IDirectoryService
	{
		public DirectoryService ()
		{
			_randomUserService = RestService.For<IRandomUserService> ("http://api.randomuser.me");
		}

		private IRandomUserService _randomUserService;

		public async Task<IEnumerable<Person>> GetPeopleAsync (PagedDataQuery query)
		{
			var result = new List<Person> ();

			try {

				var peoplePayload = await _randomUserService.GetRandomPeople (query.PageSize);

				//Delay an additional time to simulate long running 
				await Task.Delay (TimeSpan.FromSeconds (1));

				var people = from userResult in peoplePayload.results
				             select new Person {
					DisplayName = userResult.user.name.first.UppercaseFirst () + " " + userResult.user.name.last.UppercaseFirst (),
					PhoneNumber = userResult.user.phone,
					Email = userResult.user.email,
					Picture = userResult.user.picture
				};

				result.AddRange (people);

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

			} catch (Exception ex) {
				//todo replace with proper error handling
				Debug.WriteLine (ex);
			}

			return result;
		}


		private static string GetEmbeddedResourceString (Assembly assembly, string resourceFileName)
		{
			var stream = GetEmbeddedResourceStream (assembly, resourceFileName);

			using (var streamReader = new StreamReader (stream)) {
				return streamReader.ReadToEnd ();
			}
		}

		private static Stream GetEmbeddedResourceStream (Assembly assembly, string resourceFileName)
		{
			var resourceNames = assembly.GetManifestResourceNames ();

			var resourcePaths = resourceNames
				.Where (x => x.EndsWith (resourceFileName, StringComparison.CurrentCultureIgnoreCase))
				.ToArray ();

			if (!resourcePaths.Any ()) {
				throw new Exception (string.Format ("Resource ending with {0} not found.", resourceFileName));
			}

			if (resourcePaths.Count () > 1) {
				throw new Exception (string.Format ("Multiple resources ending with {0} found: {1}{2}", resourceFileName, Environment.NewLine, string.Join (Environment.NewLine, resourcePaths)));
			}

			return assembly.GetManifestResourceStream (resourcePaths.Single ());
		}

	}
}

