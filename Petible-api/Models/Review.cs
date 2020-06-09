using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Review
    {
        public virtual string id { get; set; }
        public virtual string user_id_source { get; set; }
        public virtual string user_id_target { get; set; }
        public virtual int rating { get; set; }
        public virtual string title { get; set; }
        public virtual string text { get; set; }
    }
}
