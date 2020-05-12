using FluentNHibernate.Mapping;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class AnimalShelterMap : ClassMap<AnimalShelter>
    {
        public AnimalShelterMap()
        {
            Table("animalshelter");
            Id(x => x.id).Column("id");
            Map(x => x.name).Column("name");
            Map(x => x.website).Column("webite");
            Map(x => x.postalCode).Column("postalCode");
            Map(x => x.phoneNumber).Column("phoneNumber");
            Map(x => x.bio).Column("bio");
            Map(x => x.address).Column("address");
            Map(x => x.email).Column("email");
            Map(x => x.facebook).Column("facebook");
            Map(x => x.twitter).Column("twitter");
            Map(x => x.instagram).Column("instagram");
            Map(x => x.linkedin).Column("linkedin");
        }
    }
}