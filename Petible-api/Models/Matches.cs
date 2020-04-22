using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Matches
    {
        public string idMatches { get; set; }
        public string user { get; set; }
        public int pet { get; set; }
        public bool unmatched { get; set; }
    }
}
