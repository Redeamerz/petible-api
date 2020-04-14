using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class AnimalShelter
    {
        public Guid idAnimalShelter { get; set; }
        public Guid idUser { get; set; }
        public string name { get; set; }
        public string website { get; set; }
        public string location { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }

        public AnimalShelter(Guid idAnimalShelter, Guid idUser, string name, string website, string location, string phoneNumber, string email)
        {
            this.idAnimalShelter = idAnimalShelter;
            this.idUser = idUser;
            this.name = name;
            this.website = website;
            this.location = location;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
    }
}
