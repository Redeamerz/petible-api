using Petible_api.Interfaces;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Repository
{
    public class MatchRepository : Repository<Match, string>, IMatchRepository
    {
        public MatchRepository(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
