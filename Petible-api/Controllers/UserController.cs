using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petible_api.Interfaces;
using Petible_api.Mapping;
using Petible_api.Models;

namespace Petible_api.Controllers
{
    
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUnitOfWork uow = null;
        IUserRepository userRepository = null;

        public UserController(IUnitOfWork uow, IUserRepository userRepository)
        {
            this.uow = uow;
            this.userRepository = userRepository;
        }

        // GET: api/UserInfo
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await userRepository.ListAll());
        }

        //GET: api/UserInfo/GUID
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            User user = await userRepository.FindById(id);
            if (user == null) return BadRequest();
            else return Ok(user);
        }

        //POST: api/User
        //[Authorize]
        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]User user)
        {
            try
            {
                await userRepository.Save(user);
                await uow.Commit();
                return Created("petible.nl/User", user.id);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]User user)
        {
            try
            {
                await userRepository.Remove(user);
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
