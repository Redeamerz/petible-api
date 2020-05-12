using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petible_api.enums;

namespace Petible_api.Models
{
    public class UserInfo
    {
        public virtual string id { get; set; }
        public virtual string city { get; set; }
        public virtual DateTime dateOfBirth { get; set; }
        public virtual bool children { get; set; }
        public virtual bool gender { get; set; }
        public virtual string username { get; set; }
        public virtual string description { get; set; }
        public virtual int timeFree { get; set; }
        public virtual bool otherPets { get; set; }
    }
}
