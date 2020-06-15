//using Microsoft.EntityFrameworkCore;
//using NHibernate.Criterion;
//using Org.BouncyCastle.Asn1.IsisMtt.X509;
//using Petible_api.Interfaces;
//using Petible_api.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Petible_api.Repository
//{
//	public class Pet_has_PersonalityTraitsRepository : Repository<Pet_has_PersonalityTraits, string>, IPet_has_personalitytraitsRepository
//	{
//		IUnitOfWork uow;
//		public Pet_has_PersonalityTraitsRepository(IUnitOfWork uow) : base(uow)
//		{
//			this.uow = uow;
//		}
//		public async Task<Pet_has_PersonalityTraits> ListAllById(string id) {
//			List<Pet_has_PersonalityTraits> some = await uow.Session.Query<Pet_has_PersonalityTraits>().ToListAsync();
//			List<Pet_has_PersonalityTraits> somes =  some.FindAll(x => x.pet_id == id);
//			return null;
//		}
//	}
//}
