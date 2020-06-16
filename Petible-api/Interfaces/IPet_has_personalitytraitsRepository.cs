using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Interfaces
{
	public interface IPet_has_personalitytraitsRepository : IRepository<Pet_has_PersonalityTraits, string>
	{
		Task<List<Quirk>> ListAllById(string id);
	}
}
