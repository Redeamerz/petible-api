using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public class PetMedicalInfo
    {
        public virtual string id { get; set; }
        public virtual bool chipped { get; set; }
        public virtual bool vaccinesUptodate { get; set; }
    }
}
