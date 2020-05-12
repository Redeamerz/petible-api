using FluentNHibernate.Mapping;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class Pet_has_PersonalityTraitsMap : ClassMap<Pet_has_PersonalityTraits>
    {
        public Pet_has_PersonalityTraitsMap()
        {
            Table("pet_has_personalitytraits");
            Id(x => x.pet_id).Column("pet_id");
            Map(x => x.personalitytraits_id).Column("personalitytraits_id");
        }
    }
}