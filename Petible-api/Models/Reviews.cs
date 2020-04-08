using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Reviews
    {
        public Guid idReviews { get; set; }
        public short rating { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public string title { get; set; }
        public string text { get; set; }
    }
}
