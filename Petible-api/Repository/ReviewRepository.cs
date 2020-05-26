using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Repository
{
    public class ReviewRepository : Repository<Reviews, string>, IReviewRepository
    {
        public ReviewRepository(IUnitOfWork uow): base(uow)
        {

        }
    }
}
