using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petible_api.Interfaces;
using Petible_api.Models;
using Petible_api.Repository;

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
        public async Task<UserInfo> Get(int id)
        {
            Guid guid = new Guid("af12a189-7e38-11ea-a63b-005056a73cc6");
            return await userInfoRepository.FindBy(guid);
        }

        // POST: api/UserInfo
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
