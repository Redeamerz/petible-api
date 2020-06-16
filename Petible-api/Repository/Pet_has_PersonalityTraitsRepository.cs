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
		public async Task<List<Pet_has_PersonalityTraits>> ListAllById(string id)
		{
			List<Pet_has_PersonalityTraits> list = await uow.Session.Query<Pet_has_PersonalityTraits>()
				.Where(pet => id.Contains(pet.pet_id))
				.Select(pet => pet).ToListAsync();
			return list;
		}
	}
}
