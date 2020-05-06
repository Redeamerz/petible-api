using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class ReviewsMap : ClassMap<Reviews>
    {
        public ReviewsMap()
        {
            Table("reviews");
            Id(x => x.id).Column("id");
            Map(x => x.user_id_source).Column("user_id_source");
            Map(x => x.user_id_target).Column("user_id_target");
            Map(x => x.title).Column("title");
            Map(x => x.rating).Column("rating");
            Map(x => x.text).Column("text");
        }
    }
}