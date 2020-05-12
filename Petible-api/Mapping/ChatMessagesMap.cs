using FluentNHibernate.Mapping;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class ChatMessagesMap : ClassMap<ChatMessages>
    {
        public ChatMessagesMap()
        {
            Table("chatmessages");
            Id(x => x.id).Column("id");
            Map(x => x.user_id_source).Column("user_id_source");
            Map(x => x.user_id_target).Column("user_id_target");
            Map(x => x.matches_id).Column("matches_id");
            Map(x => x.message).Column("message");
        }
    }
}
