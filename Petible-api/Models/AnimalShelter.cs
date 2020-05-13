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
        public virtual string postalCode { get; set; }
        public virtual string city { get; set; }
        public virtual string address { get; set; }
        public virtual decimal longitude { get; set; }
        public virtual decimal latitude { get; set; }
        public virtual string phoneNumber { get; set; }
        public virtual string email { get; set; }
        public virtual string bio { get; set; }
        public virtual string facebook { get; set; }
        public virtual string twitter { get; set; }
        public virtual string instagram { get; set; }
        public virtual string linkedin { get; set; }
    }
}
