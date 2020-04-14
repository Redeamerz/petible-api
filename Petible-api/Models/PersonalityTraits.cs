using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class PersonalityTraits
    {
        public int idPersonalityTraits { get; set; }
        public string personality { get; set; }
        public string description { get; set; }

        public PersonalityTraits(int idPersonalityTraits, string personality, string description)
        {
            this.idPersonalityTraits = idPersonalityTraits;
            this.personality = personality;
            this.description = description;
        }
    }
}
