using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Repository
{
    public class MatchesRepository : Repository<Matches, string>, IMatchesRepository
    {
        public MatchesRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
