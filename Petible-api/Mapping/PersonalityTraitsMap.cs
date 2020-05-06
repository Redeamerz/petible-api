using FluentNHibernate.Mapping;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class PersonalityTraitsMap : ClassMap<PersonalityTraits>
    {
        public PersonalityTraitsMap()
        {
            Table("personalitytraits");
            Id(x => x.id).Column("id");
            Map(x => x.personality).Column("personality");
            Map(x => x.description).Column("description");
        }
    }
}