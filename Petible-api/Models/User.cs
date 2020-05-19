using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class User
    {        
        public virtual string id { get; set; }
        public virtual string email { get; set; }
        public virtual int role { get; set; }
    }
}
