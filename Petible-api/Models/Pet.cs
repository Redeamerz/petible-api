using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Pet
    {
        public int idPet { get; set; }
        public Guid idUser { get; set; }
        public string PetType { get; set; }
        public string name { get; set; }
        public DateTime dateOfBirth { get; set; }
        public bool gender { get; set; }
        public string description { get; set; }
        public DateTime inAnimalShelterSince { get; set; }
        public bool chipped { get; set; }
        public bool goodWithChildren { get; set; }
        public bool sterilzed { get; set; }
        public bool vaccinesUpToDate { get; set; }
        public bool medicalBackpack { get; set; }
        public int costs { get; set; }

    }
}
