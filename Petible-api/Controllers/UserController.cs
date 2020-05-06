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
        public async Task<List<User>> GetAsync()
        {
            return await userRepository.ListAll();
        }

        //GET: api/UserInfo/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            string guid = new string("asdfawfawef2qf4af");
            return await userRepository.FindBy(guid);
        }

        //POST: api/User
       [HttpPut]
       [ProducesResponseType(StatusCodes.Status201Created)]
        public void Put()
        {

            User user = new User();
            user.id = "67aea08b-849f-11ea-ab04-005056a73cc6";
            user.email = "randomemailhere@dddd.nl";
            userRepository.Save(user);
            uow.Commit();
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
