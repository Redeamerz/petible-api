using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Pet_has_PetType
    {
        public virtual string pet_id { get; set; }
        public virtual string petType_id { get; set; }
    }
}
