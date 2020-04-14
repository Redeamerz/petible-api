using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Pet
    {
        public Guid idPet { get; set; }
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
        public int costs { get; set; }

        public Pet(Guid idPet, Guid idUser, string petType, string name, DateTime dateOfBirth, bool gender, string description, DateTime inAnimalShelterSince, bool chipped, bool goodWithChildren, bool sterilzed, bool vaccinesUpToDate, int costs)
        {
            this.idPet = idPet;
            this.idUser = idUser;
            PetType = petType;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.description = description;
            this.inAnimalShelterSince = inAnimalShelterSince;
            this.chipped = chipped;
            this.goodWithChildren = goodWithChildren;
            this.sterilzed = sterilzed;
            this.vaccinesUpToDate = vaccinesUpToDate;
            this.costs = costs;
        }
    }
}
