using Petible_api.Models;
using Petible_api.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Interfaces
{
    public interface IMatchRepository : IRepository<Match, string>
    {
        Task<Match> GetMatchInfo(string id);
        Task<List<MatchForShelter>> GetMatchesByAnimalId(string id);
        Task<List<MatchForShelter>> GetMatchesByUserId(string id);
    }
}
