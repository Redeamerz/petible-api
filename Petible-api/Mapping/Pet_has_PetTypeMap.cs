using FluentNHibernate.Mapping;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class Pet_has_PetTypeMap : ClassMap<Pet_has_PetType>
    {
        public Pet_has_PetTypeMap()
        {
            Table("pet_has_pettype");
            Id(x => x.pet_id).Column("pet_id");
            Map(x => x.petType_id).Column("petType_id");
        }
    }
}
