using Petible_api.Interfaces;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Repository
{
    public class PetMedicalInfoRepository : Repository<PetMedicalInfo, string>, IPetMedicalInfoRepository
    {
        public PetMedicalInfoRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
