using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Interfaces
{
    public interface IMatchesRepository : IRepository<Matches, string>
    {
        Task<Matches> GetMatchInfo(string id);

    }
}
