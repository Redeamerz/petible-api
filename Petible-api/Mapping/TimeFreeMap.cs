using FluentNHibernate.Mapping;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class TimeFreeMap : ClassMap<TimeFree>
    {
        public TimeFreeMap()
        {
            Table("timefree");
            Id(x => x.id).Column("id");
            Map(x => x.name).Column("name");
            Map(x => x.timeFree).Column("timeFree");
        }
    }
}
