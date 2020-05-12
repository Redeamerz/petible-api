using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class TimeFree
    {
        public virtual string id { get; set; }
        public virtual string name { get; set; }
        public virtual int timeFree { get; set; }
    }
}
