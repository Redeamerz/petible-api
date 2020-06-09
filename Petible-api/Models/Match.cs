using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Matches
    {
        public virtual string id { get; set; }
        public virtual int pet_id { get; set; }
        public virtual bool unmatched { get; set; }
    }
}
