using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AnimalShelterController : ControllerBase
    {
        IUnitOfWork uow = null;
        IAnimalShelterRepository animalShelterRepository = null;

        public AnimalShelterController(IUnitOfWork uow, IAnimalShelterRepository animalShelterRepository)
        {
            this.uow = uow;
            this.animalShelterRepository = animalShelterRepository;
        }
        // GET: api/AnimalShelter
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            return Ok(await animalShelterRepository.ListAll());
        }

        // GET: api/AnimalShelter/GUID
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> Get(string id)
        {
            AnimalShelter animalShelter = await animalShelterRepository.FindById(id);
            if (animalShelter == null) return BadRequest();
            else return Ok(animalShelter);
        }

        // PUT: api/AnimalShelter
        [HttpPut]
        public async Task<IActionResult> Post([FromBody] AnimalShelter animalShelter)
        {
            try
            {
                await animalShelterRepository.Save(animalShelter);
                await uow.Commit();
                return Created("petible.nl/animalshelter", animalShelter.id);
            } catch
            {
                return BadRequest();
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<IActionResult> Deletes([FromBody] AnimalShelter animalShelter)
        {
            try
            {
                await animalShelterRepository.Remove(animalShelter);
                return NoContent();
            } catch
            {
                return BadRequest();
            }
        }
    }
}
