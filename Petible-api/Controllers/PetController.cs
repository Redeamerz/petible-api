using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        IPetRepository petRepository;
        IUnitOfWork uow;

        public PetController(IPetRepository petRepository, IUnitOfWork uow)
        {
            this.petRepository = petRepository;
            this.uow = uow;
        }

        // GET: api/Pet
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await petRepository.ListAll());
        }


        // GET: api/Pet/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gets(string id)
        {
            Pet pet = await petRepository.FindById(id);
            if (pet == null) return BadRequest();
            else return Ok(pet);
        }

        // PUT: api/Pet
        [HttpPut]
        public async Task<IActionResult> PostsAsync([FromBody] Pet pet)
        {
            try
            {
                await petRepository.Save(pet);
                await uow.Commit();
                return Created("petible.nl/pet", pet.id);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<IActionResult> Deletes(Pet pet)
        {
            try
            {
                await petRepository.Remove(pet);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
