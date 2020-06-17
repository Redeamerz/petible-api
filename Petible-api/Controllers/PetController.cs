using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Controllers
{
	[Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        IPetRepository petRepository;
        IUnitOfWork uow;
        IPet_has_personalitytraitsRepository pet_Has_PersonalitytraitsRepository;

        public PetController(IPetRepository petRepository, IPet_has_personalitytraitsRepository pet_Has_PersonalitytraitsRepository, IUnitOfWork uow)
        {
            this.petRepository = petRepository;
            this.pet_Has_PersonalitytraitsRepository = pet_Has_PersonalitytraitsRepository;
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

		// GET: api/Pet/quirk/5
        [AllowAnonymous]
		[HttpGet("quirk/{id}")]
		public async Task<IActionResult> GetsQuirkById(string id)
		{
            List<Quirk> petList = await pet_Has_PersonalitytraitsRepository.ListAllById(id);
            if (petList == null) return BadRequest();
			else return Ok(petList);
		}

		// POST: api/Pet/quirk
        [AllowAnonymous]
		[HttpPost("quirk")]
		public async Task<IActionResult> PostQuirksById(string id, [FromQuery(Name = "quirks")]List<int> quirks)
		{
            try
            {
                foreach (int quirk in quirks)
                {
                    Pet_has_PersonalityTraits petpersonality = new Pet_has_PersonalityTraits();
                    petpersonality.pet_id = id;
                    petpersonality.personalitytraits_id = quirk;
                    await pet_Has_PersonalitytraitsRepository.Save(petpersonality);
                }
                await uow.Commit();
                return Created("petpersonality",id);
            }
            catch
			{
                return BadRequest();
			}
		}

		// PUT: api/Pet
		[HttpPut]
        public async Task<IActionResult> PostsAsync([FromBody] Pet pet)
        {
            if (pet.id == null) pet.id = Guid.NewGuid().ToString();
            try
            {
                await petRepository.Save(pet);
                await uow.Commit();
                return Created("new pet created", pet);
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
                await uow.Commit();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}