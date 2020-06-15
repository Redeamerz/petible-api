using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Pet
    {
        public virtual string id { get; set; }
        public virtual string animalshelter_id { get; set; }
        public virtual string timefree { get; set; }
        public virtual string name { get; set; }
        public virtual DateTime dateOfBirth { get; set; }
        public virtual bool gender { get; set; }
        public virtual string description { get; set; }
        public virtual DateTime inAnimalShelterSince { get; set; }
        public virtual int fees { get; set; }
        public virtual int[] quirks { get; set; }
    }
}
