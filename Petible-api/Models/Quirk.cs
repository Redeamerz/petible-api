using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Quirk
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string description { get; set; }
    }
}
