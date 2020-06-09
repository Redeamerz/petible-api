using FluentNHibernate.Mapping;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class PetMedicalInfoMap : ClassMap<PetMedicalInfo>
    {
        public PetMedicalInfoMap()
        {
            Table("petmedicalinfo");
            Id(x => x.id).Column("id");
            Map(x => x.chipped).Column("chipped");
            Map(x => x.sterilized).Column("sterilized");
            Map(x => x.vaccinesUptodate).Column("vaccinesuptodate");
            Map(x => x.medicalComplications).Column("medicalcomplications");
        }
    }
}
