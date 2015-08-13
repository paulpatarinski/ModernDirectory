using System.Threading.Tasks;
using ModernDirectory.Models;
using Refit;
using System.Globalization;

namespace ModernDirectory.Services
{
	public interface IGooglePlusApi
	{
		[Get("/people/me/people/visible?maxResults={pageSize}&pageToken={nextPageToken}&fields=items(cover%2CdisplayName%2Cemails%2Cgender%2Cimage%2Cname%2Corganizations%2Fname)%2CnextPageToken")]
		[Headers("Authorization: Bearer")]
		Task<GooglePeoplePayload> GetPeopleAsync(int pageSize, string nextPageToken);

		[Get("/people?query={searchQuery}&maxResults={pageSize}&pageToken={nextPageToken}&fields=items(displayName%2Cgender%2Cimage%2Cname)%2CnextPageToken")]
		[Headers("Authorization: Bearer")]
		Task<GooglePeoplePayload> SearchPeopleAsync(string searchQuery, int pageSize, string nextPageToken);
	}
}

