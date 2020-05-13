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
        IAnimalShelterRepository animalShelterRepository;
        IUnitOfWork uow;

        public AnimalShelterController(IAnimalShelterRepository animalShelterRepository, IUnitOfWork uow)
        {
            this.animalShelterRepository = animalShelterRepository;
            this.uow = uow;
        }
        // GET: api/AnimalShelter
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await animalShelterRepository.ListAll());
        }

        // GET: api/AnimalShelter/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gets(string id)
        {
            AnimalShelter animalShelter = await animalShelterRepository.FindById(id);
            if (animalShelter == null) return BadRequest();
            else return Ok(animalShelter);
        }

        // PUT: api/AnimalShelter
        [HttpPut]
        public async Task<IActionResult> PostsAsync([FromBody] AnimalShelter animalShelter)
        {
            try
            {
                await animalShelterRepository.Save(animalShelter);
                await uow.Commit();
                return Created("petible.nl/animalshelter", animalShelter.id);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<IActionResult> Deletes(AnimalShelter animalShelter)
        {
            try
            {
                await animalShelterRepository.Remove(animalShelter);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
