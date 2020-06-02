using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petible_api.Interfaces;
using Petible_api.Models;
using Petible_api.Repository;

namespace Petible_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        IMatchesRepository matchesRepository;
        IUnitOfWork uow;

        public MatchesController(IMatchesRepository matchesRepository, IUnitOfWork uow)
        {
            this.matchesRepository = matchesRepository;
            this.uow = uow;
        }

        // GET: api/Matches
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await matchesRepository.ListAll());
        }

        // GET: api/Matches/5
        //TODO authenticate
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Matches matches = await matchesRepository.FindById(id);
            if (matches == null) return BadRequest();
            else return Ok(matches);
        }

        // POST: api/Matches
        [HttpPost]
        public async Task<IActionResult> PostsAsync([FromBody] Matches matches)
        {
            try
            {
                await matchesRepository.Save(matches);
                await uow.Commit();
                return Created("petible.nl/matches", matches.id);
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
