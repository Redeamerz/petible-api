using FluentNHibernate.Mapping;
using Petible_api.Models;

namespace Petible_api.Mapping
{
    public class UserInfoMap : ClassMap<UserInfo>
    {
        public UserInfoMap()
        {
            Table("userinfo");
            Id(x => x.id, "id");
            Map(x => x.city);

            Map(x => x.dateOfBirth);

            Map(x => x.children);

            Map(x => x.gender);

            Map(x => x.username);

            Map(x => x.description);

            Map(x => x.timeFree_id);

            Map(x => x.otherPets);
        }

    }
}
