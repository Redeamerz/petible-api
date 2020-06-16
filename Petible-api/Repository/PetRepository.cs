using Microsoft.VisualBasic;
using Petible_api.Interfaces;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Repository
{
    public class PetRepository : Repository<Pet, string>, IPetRepository
    {
		IUnitOfWork uow;
		public PetRepository(IUnitOfWork uow) : base(uow)
        {
			this.uow = uow;
		}

		public async Task<List<Pet>> GetOnShelterId(string id)
		{
			List<Pet> pets = new List<Pet>();
			var result = await uow.Session.CreateSQLQuery($"SELECT id, name, inanimalsheltersince FROM pet WHERE animalshelter_id = '{id}'").ListAsync();
			for (int i = 0; i < result.Count; i++)
			{
				var temp = (object[])result[i];
				Pet pet = new Pet();
				pet.id = (string)temp[0];
				pet.name = (string)temp[1];
				pet.inAnimalShelterSince = (DateTime)temp[2];
				pets.Add(pet);
			}
			return pets;
		}
	}
}
