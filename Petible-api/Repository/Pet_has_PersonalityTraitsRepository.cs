using NHibernate.Criterion;
using NHibernate.Linq;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using Petible_api.Interfaces;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Repository
{
	public class Pet_has_PersonalityTraitsRepository : Repository<Pet_has_PersonalityTraits, string>, IPet_has_personalitytraitsRepository
	{
		IUnitOfWork uow;
		public Pet_has_PersonalityTraitsRepository(IUnitOfWork uow) : base(uow)
		{
			this.uow = uow;
		}
		public async Task<List<Quirk>> ListAllById(string id)
		{
			List<Quirk> quirks = new List<Quirk>();
			var result = await uow.Session.CreateSQLQuery($"SELECT p.Id, p.personality, p.description FROM pet_has_personalitytraits ph INNER JOIN personalitytraits p ON ph.personalitytraits_id = p.Id WHERE ph.pet_id = '{id}'").ListAsync();
			for (int i = 0; i < result.Count; i++)
			{
				var temp = (object[])result[i];
				Quirk quirk = new Quirk();
				quirk.id = (int)temp[0];
				quirk.name = (string)temp[1];
				quirk.description = (string)temp[2];
				quirks.Add(quirk);
			}
			return quirks;
		}
	}
}
