using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Pet_has_PersonalityTraits
    {
        public int idPet { get; set; }
        public int idPersonalityTraits { get; set; }

        public Pet_has_PersonalityTraits(int idPet, int idPersonalityTraits)
        {
            this.idPet = idPet;
            this.idPersonalityTraits = idPersonalityTraits;
        }
    }
}
