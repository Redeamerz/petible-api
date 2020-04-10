using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petible_api.enums;

namespace Petible_api.Models
{
    public class UserInfo
    {
        public Guid idUserInfo { get; set; }
        public Guid idUser { get; set; }
        public string city { get; set; }
        public DateTime dateOfBirth { get; set; }
        public bool children { get; set; }
        public bool gender { get; set; }
        public string nickname { get; set; }
        public string description { get; set; }
        public short timeFreePerDayInMinutes { get; set; }
        public bool otherPets { get; set; }

        public UserInfo(Guid idUserInfo, Guid idUser, string city, DateTime dateOfBirth, bool children, bool gender, string nickname, string description, short timeFreePerDayInMinutes, bool otherPets)
        {
            this.idUserInfo = idUserInfo;
            this.idUser = idUser;
            this.city = city;
            this.dateOfBirth = dateOfBirth;
            this.children = children;
            this.gender = gender;
            this.nickname = nickname;
            this.description = description;
            this.timeFreePerDayInMinutes = timeFreePerDayInMinutes;
            this.otherPets = otherPets;
        }
    }
}
