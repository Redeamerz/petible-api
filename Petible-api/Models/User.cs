using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class User
    {        
        public virtual string idUser { get; set; }
        public virtual string email { get; set; }
    }
}
