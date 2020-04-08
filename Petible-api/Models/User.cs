using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class User
    {        
        public int idUser { get; set; }
        public string mail { get; set; }
        public ICollection<UserInfo> userInfo { get; set; }
        public ICollection<Reviews> reviews { get; set; }
        public ICollection<Matches> matches { get; set; }
    }
}
