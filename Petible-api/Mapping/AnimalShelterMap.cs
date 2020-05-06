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
            Map(x => x.location).Column("location");
            Map(x => x.phoneNumber).Column("phoneNumber");
            Map(x => x.description).Column("description");
        }
    }
}
