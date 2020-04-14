using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class User
    {        
        public Guid idUser { get; set; }
        public string mail { get; set; }
        public ICollection<UserInfo> userInfo { get; set; }
        public ICollection<Reviews> reviews { get; set; }
        public ICollection<Matches> matches { get; set; }

        public User(Guid idUser, string mail, ICollection<UserInfo> userInfo, ICollection<Reviews> reviews, ICollection<Matches> matches)
        {
            this.idUser = idUser;
            this.mail = mail;
            this.userInfo = userInfo;
            this.reviews = reviews;
            this.matches = matches;
        }
    }
}
