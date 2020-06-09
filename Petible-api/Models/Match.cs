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
        public virtual string user_id { get; set; }
        public virtual int status { get; set; }
    }
}
