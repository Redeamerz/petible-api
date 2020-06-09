using FluentNHibernate.Mapping;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class MatchesMap : ClassMap<Match>
    {
        public MatchesMap()
        {
            Table("matches");
            Id(x => x.id).Column("id");
            Map(x => x.pet_id).Column("pet_id");
            Map(x => x.user_id).Column("user_id");
            Map(x => x.status).Column("status");
            Map(x => x.shelterEmail).Column("shelteremail");
        }
    }
}
