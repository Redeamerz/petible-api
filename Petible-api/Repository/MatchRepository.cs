using NHibernate;
using NHibernate.Linq;
using Petible_api.Interfaces;
using Petible_api.Models;
using Petible_api.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Repository
{
	public class MatchRepository : Repository<Match, string>, IMatchRepository
	{
		IUnitOfWork uow;
		public MatchRepository(IUnitOfWork uow) : base(uow)
		{
			this.uow = uow;
		}
		public async Task<List<Match>> GetMatchInfo(string id)
		{
			var result = await uow.Session.CreateSQLQuery($"SELECT matches.id, matches.pet_id, pet.name, matches.status, animalshelter.email FROM matches INNER JOIN pet ON matches.pet_id = pet.id INNER JOIN animalshelter ON pet.animalshelter_id = animalshelter.id WHERE matches.user_id = '{id}'").ListAsync();
			List<Match> matches = new List<Match>();
			for (int i = 0; i < result.Count; i++)
			{
				var temp = (object[])result[i];

				Match match = new Match();
					match.id = (string)temp[0];
					match.pet_id = (string)temp[1];
					match.petName = (string)temp[2];
					match.status = (int)temp[3];
					match.animalShelterEmail = (string)temp[4];
					matches.Add(match);
				
			}
			
			return matches;
		}

		public async Task<List<MatchForShelter>> GetMatchesByAnimalId(string id)
		{
			List<MatchForShelter> matches = new List<MatchForShelter>();
			var result = await uow.Session.CreateSQLQuery($"SELECT m.user_id, u.username, m.status, m.id FROM matches m INNER JOIN userinfo u ON u.id = m.user_id WHERE m.pet_id = '{id}'").ListAsync();
			for (int i = 0; i < result.Count; i++)
			{
				var temp = (object[])result[i];
				MatchForShelter match = new MatchForShelter();
				match.id = (string)temp[0];
				match.name = (string)temp[1];
				match.status = (int)temp[2];
				match.match_id = (string)temp[3];
				matches.Add(match);
			}
			return matches;
		}

		public async Task<List<MatchForShelter>> GetMatchesByUserId(string id)
		{
			List<MatchForShelter> matches = new List<MatchForShelter>();
			var result = await uow.Session.CreateSQLQuery($"SELECT * FROM matches m INNER JOIN userinfo u ON u.id = m.user_id WHERE m.user_id = '{id}'").ListAsync();
			for (int i = 0; i < result.Count; i++)
			{
				var temp = (object[])result[i];
				MatchForShelter match = new MatchForShelter();
				match.id = (string)temp[0];
				match.name = (string)temp[1];
				matches.Add(match);
			}
			return matches;
		}
	}
}