using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class ChatMessages
    {
        public int idChatMessage { get; set; }
        public int idMatches { get; set; }
        public int rating { get; set; }
        public string message { get; set; }
        public string source { get; set; }
        public string target { get; set; }

        public ChatMessages(int idChatMessage, int idMatches, int rating, string message, string source, string target)
        {
            this.idChatMessage = idChatMessage;
            this.idMatches = idMatches;
            this.rating = rating;
            this.message = message;
            this.source = source;
            this.target = target;
        }
    }
}
