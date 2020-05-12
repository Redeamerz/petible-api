using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petible_api.Interfaces;
using Petible_api.Models;

namespace Petible_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        IUnitOfWork uow = null;
        IUserInfoRepository userInfoRepository = null;

        public UserInfoController(IUnitOfWork uow, IUserInfoRepository userInfoRepository)
        {
            this.uow = uow;
            this.userInfoRepository = userInfoRepository;
        }

        // GET: api/UserInfo
        [HttpGet]
        public async Task<List<UserInfo>> GetAsync()
        {
            return await userInfoRepository.ListAll();
        }

        // GET: api/UserInfo/5
        [HttpGet("{id}")]
        public async Task<UserInfo> Get([FromBody]UserInfo user)
        {
            return await userInfoRepository.FindBy(user.id);
        }

        // POST: api/UserInfo
        [HttpPut]
        public async Task<IActionResult> Post([FromBody]UserInfo userInfo)
        {
            await userInfoRepository.Save(userInfo);
            await uow.Commit();
            return Created("petible.nl", userInfo.id);
            
        }
            
        // PUT: api/UserInfo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
