using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Controllers
{
	//[Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        IPetRepository petRepository;
        IUnitOfWork uow;
        IPet_has_personalitytraitsRepository pet_Has_Personalitytraits;

        public PetController(IPetRepository petRepository, IPet_has_personalitytraitsRepository pet_Has_Personalitytraits, IUnitOfWork uow)
        {
            this.petRepository = petRepository;
            this.pet_Has_Personalitytraits = pet_Has_Personalitytraits;
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

        [HttpGet("shelter/{id}")]
        public async Task<IActionResult> GetOnShelterId(string id)
        {
            List<Pet> pet = await petRepository.GetOnShelterId(id);
            if (pet == null) return BadRequest();
            else return Ok(pet);
        }
        //// GET: api/Pet/quirk/5
        //[AllowAnonymous]
        //[HttpGet("quirk/{id}")]
        //public async Task<IActionResult> GetsQuirkById(string id)
        //{
        //    Pet_has_PersonalityTraits petTraits = await pet_Has_Personalitytraits.ListAllById(id);
        //    if (pet_Has_Personalitytraits == null) return BadRequest();
        //    else return Ok(petTraits);
        //}

        //// POST: api/Pet/quirk
        //[HttpGet("quirk/{id}")]
        //public async Task<IActionResult> GetsQuirkById(string id)
        //{
        //    Pet_has_PersonalityTraits petTraits = await pet_Has_Personalitytraits.FindById(id);
        //    if (pet_Has_Personalitytraits == null) return BadRequest();
        //    else return Ok(petTraits);
        //}

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