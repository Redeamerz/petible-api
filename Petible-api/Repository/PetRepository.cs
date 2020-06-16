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
			var result = await uow.Session.CreateSQLQuery($"SELECT id, animalshelter_id, timefree, name, dateofbirth, gender, description, inanimalsheltersince, fees FROM pet WHERE animalshelter_id = '{id}'").ListAsync();
			for (int i = 0; i < result.Count; i++)
			{
				var temp = (object[])result[i];
				Pet pet = new Pet();
				pet.id = (string)temp[0];
				pet.animalshelter_id = (string)temp[1];
				pet.timefree = (int)temp[2];
				pet.name = (string)temp[3];
				pet.dateOfBirth = (DateTime)temp[4];
				pet.gender = Convert.ToBoolean((UInt64)temp[5]);
				pet.description = (string)temp[6];
				pet.inAnimalShelterSince = (DateTime)temp[7];
				pet.fees = Convert.ToInt32((decimal)temp[8]);
				pets.Add(pet);
			}
			return pets;
		}
	}
}
