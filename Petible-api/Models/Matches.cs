using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Matches
    {
        public int idMatches { get; set; }
        public Guid user { get; set; }
        public int pet { get; set; }
        public bool unmatched { get; set; }
    }
}
