using FluentNHibernate.Mapping;
using Petible_api.Models;

namespace Petible_api.Mapping
{
    public class UserInfoMap : ClassMap<UserInfo>
    {
        public UserInfoMap()
        {
            Table("userinfo");

            Id(x => x.id).Column("id").UniqueKey("id");

            Map(x => x.city).Column("city");

            Map(x => x.children).Column("children");

            Map(x => x.username).Column("username");

            Map(x => x.description).Column("description");

            Map(x => x.timeFree).Column("timeFree");

            Map(x => x.otherPets).Column("otherPets");

            Map(x => x.latitude).Column("latitude");

            Map(x => x.longitude).Column("longitude");
        }
    }
}
