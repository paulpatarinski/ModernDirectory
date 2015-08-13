using System.Threading.Tasks;
using ModernDirectory.Models;
using Refit;
using System.Globalization;

namespace ModernDirectory.Services
{
	public interface IGooglePlusApi
	{
		[Get("/people/me/people/visible")]
		[Headers("Authorization: Bearer")]
		Task<GooglePeoplePayload> GetPeopleAsync();

		[Get("/people?query={searchQuery}&maxResults={pageSize}&pageToken={nextPageToken}&fields=items(displayName%2Cgender%2Cimage%2Cname)%2CnextPageToken")]
		[Headers("Authorization: Bearer")]
		Task<GooglePeoplePayload> SearchPeopleAsync(string searchQuery, int pageSize, string nextPageToken);
	}
}

