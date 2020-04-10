using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petible_api.enums;

namespace Petible_api.Models
{
    public class UserInfo
    {
        public virtual Guid idUserInfo { get; set; }
        public virtual Guid idUser { get; set; }
        public virtual string city { get; set; }
        public virtual int dateOfBirth { get; set; }
        public virtual bool children { get; set; }
        public virtual bool gender { get; set; }
        public virtual string nickname { get; set; }
        public virtual string description { get; set; }
        public virtual short timeFreePerDayInMinutes { get; set; }
        public virtual bool otherPets { get; set; }

        //public UserInfo(Guid idUserInfo, Guid idUser, string city, DateTime dateOfBirth, bool children, bool gender, string nickname, string description, short timeFreePerDayInMinutes, bool otherPets)
        //{
        //    this.idUserInfo = idUserInfo;
        //    this.idUser = idUser;
        //    this.city = city;
        //    this.dateOfBirth = dateOfBirth;
        //    this.children = children;
        //    this.gender = gender;
        //    this.nickname = nickname;
        //    this.description = description;
        //    this.timeFreePerDayInMinutes = timeFreePerDayInMinutes;
        //    this.otherPets = otherPets;
        //}
    }
}
