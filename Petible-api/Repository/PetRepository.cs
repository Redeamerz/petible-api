using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Repository
{
    public class PetRepository : Repository<Pet, string>, IPetRepository
    {
        public PetRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
