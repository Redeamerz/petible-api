﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class Quirk
    {
        public virtual string id { get; set; }
        public virtual string personality { get; set; }
        public virtual string description { get; set; }
    }
}
