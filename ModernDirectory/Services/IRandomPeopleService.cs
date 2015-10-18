﻿using System;
using Refit;
using System.Threading.Tasks;
using ModernDirectory.Models;
using System.Collections.Generic;

namespace ModernDirectory.Services
{
	public interface IRandomPeopleService
	{
		[Get ("/?results={numOfPeople}")]
		Task<RandomUsersPayload> GetRandomPeople (int numOfPeople);
	}
}

