using FluentNHibernate.Mapping;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class QuirkMap : ClassMap<Quirk>
    {
        public QuirkMap()
        {
            Table("personalitytraits");
            Id(x => x.id).Column("id");
            Map(x => x.name).Column("personality");
            Map(x => x.description).Column("description");
        }
    }
}
