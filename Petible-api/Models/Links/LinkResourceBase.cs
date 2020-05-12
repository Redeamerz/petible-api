using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models.Links
{
    public class LinkResourceBase
    {
        public LinkResourceBase() { }

        public List<Link> links { get; set; } = new List<Link>();
    }
}
