using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Repository
{
    public class AnimalShelterRepository : Repository<AnimalShelter, string>, IAnimalShelterRepository
    {
        public AnimalShelterRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
