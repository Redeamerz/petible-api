using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Repository
{
    public class ReviewRepository : Repository<AnimalShelter, string>, IAnimalShelterRepository
    {
        public ReviewRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
