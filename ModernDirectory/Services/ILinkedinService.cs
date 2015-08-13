using System;
using System.Threading.Tasks;
using ModernDirectory.Models;
using System.Collections.Generic;
using Refit;

namespace ModernDirectory.Services
{
	public interface ILinkedinService
	{
		[Get("/people/~:(first-name,last-name,picture-url)?oauth2_access_token={authorization}")]
		[Headers("x-li-format: json")]
		Task<Person> GetPeopleAsync (string authorization);
	}
}

