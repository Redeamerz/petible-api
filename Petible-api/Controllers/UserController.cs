using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await userRepository.ListAll());
        }

        //GET: api/UserInfo/GUID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            User user = await userRepository.FindBy(id);
            if (user == null) return BadRequest();
            else return Ok(user);
        }

        //POST: api/User
       [HttpPut]
        public async Task<IActionResult> Put([FromBody]User user)
        {
            try
            {
                await userRepository.Save(user);
                await uow.Commit();
                return Created("lifelinks.nl/User", user.id);
            }
            catch(Exception x)
            {
                return BadRequest();
            }

        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Puta(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
