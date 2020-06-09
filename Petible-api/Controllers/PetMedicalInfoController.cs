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
    public class PetMedicalInfoController : ControllerBase
    {
        IUnitOfWork uow = null;
        IPetMedicalInfoRepository petMedicalInfoRepository = null;

        public PetMedicalInfoController(IUnitOfWork uow, IPetMedicalInfoRepository petMedicalInfoRepository)
        {
            this.uow = uow;
            this.petMedicalInfoRepository = petMedicalInfoRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await petMedicalInfoRepository.ListAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            PetMedicalInfo petMedicalInfo = await petMedicalInfoRepository.FindById(id);
            if (petMedicalInfo == null) return BadRequest();
            else return Ok(petMedicalInfo);
        }

        [HttpPut]
        public async Task<IActionResult> Post([FromBody] PetMedicalInfo petMedicalInfo)
        {
            try
            {
                await petMedicalInfoRepository.Save(petMedicalInfo);
                await uow.Commit();
                return Created("petible.nl", petMedicalInfo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] PetMedicalInfo petMedicalInfo)
        {
            await petMedicalInfoRepository.Remove(petMedicalInfo);
            await uow.Commit();
            return NoContent();
        }
    }
}
