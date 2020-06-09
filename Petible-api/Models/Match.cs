using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Match
    {
        public virtual string id { get; set; }
        public virtual string pet_id { get; set; }
        public virtual int timeFree { get; set; }
        public virtual string name { get; set; }
        public virtual DateTime dateOfBirth { get; set; }
        public virtual bool gender { get; set; }
        public virtual string description { get; set; }
        public virtual DateTime inAnimalShelterSince { get; set; }
        public virtual int fees { get; set; }
    }
}
