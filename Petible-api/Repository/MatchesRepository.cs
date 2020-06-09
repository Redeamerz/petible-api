using NHibernate;
using NHibernate.Linq;
using Petible_api.Interfaces;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Petible_api.Repository
{
	public class MatchesRepository : Repository<Matches, string>, IMatchesRepository
	{
		IUnitOfWork uow;
		public MatchesRepository(IUnitOfWork uow) : base(uow)
		{
			this.uow = uow;
		}
		public async Task<Matches> GetMatchInfo(string id)
		{
			var result = (object[])await uow.Session.CreateSQLQuery($"SELECT matches.id, matches.pet_id, pet.name, matches.status, animalshelter.email FROM matches INNER JOIN pet ON matches.pet_id = pet.id INNER JOIN animalshelter ON pet.animalshelter_id = animalshelter.id WHERE matches.pet_id = '{id}'").UniqueResultAsync();
			Matches match = new Matches();
			match.id = (string)result[0];
			match.pet_id = (string)result[1];
			match.petName = (string)result[2];
			match.status = (int)result[3];
			match.animalShelterEmail = (string)result[4];
			return match;
		}

	}
}