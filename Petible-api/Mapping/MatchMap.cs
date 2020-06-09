using FluentNHibernate.Mapping;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class MatchMap : ClassMap<Match>
    {
        public MatchMap()
        {
            Table("matches");
            Id(x => x.id).Column("id");
            Map(x => x.pet_id).Column("pet_id");
            Map(x => x.timeFree).Column("timefree");
            Map(x => x.name).Column("name");
            Map(x => x.dateOfBirth).Column("dateofbirth");
            Map(x => x.gender).Column("gender");
            Map(x => x.description).Column("description");
            Map(x => x.inAnimalShelterSince).Column("inanimalsheltersince");
            Map(x => x.fees).Column("fees");
        }
    }
}
