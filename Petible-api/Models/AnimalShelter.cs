using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class AnimalShelter
    {
        public virtual string id { get; set; }
        public virtual string name { get; set; }
        public virtual string website { get; set; }
        public virtual string location { get; set; }
        public virtual string phoneNumber { get; set; }
        public virtual string email { get; set; }
        public virtual string description { get; set; }

    }
}
