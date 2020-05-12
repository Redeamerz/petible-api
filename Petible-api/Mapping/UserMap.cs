using FluentNHibernate.Mapping;
using Petible_api.Models;

namespace Petible_api.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("user");
            Id(x => x.id, "id").Column("id");
            Map(x => x.email).Column("email");
        }

    }
}
