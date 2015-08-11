using System.Threading.Tasks;
using System.Collections.Generic;
using ModernDirectory.Models;

namespace ModernDirectory.Services
{
	public interface IDirectoryService
	{
		Task<IEnumerable<Person>> GetPeopleAsync(PagedDataQuery query);
	}
}