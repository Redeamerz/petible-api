using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        IUnitOfWork uow;
        IMatchesRepository matchesRepository;

        public MatchesController(IUnitOfWork uow, IMatchesRepository matchesRepository)
		{
            this.uow = uow;
            this.matchesRepository = matchesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await matchesRepository.ListAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Matches match = await matchesRepository.FindById(id);
            if (match == null) return BadRequest();
            else return Ok(match);
        }

        [HttpPut]
        public async Task<IActionResult> Post([FromBody] Matches match)
        {
            try
            {
                await matchesRepository.Save(match);
                await uow.Commit();
                return Created("petible.nl", match);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Matches match)
        {
            await matchesRepository.Remove(match);
            await uow.Commit();
            return NoContent();
        }
    }
}
