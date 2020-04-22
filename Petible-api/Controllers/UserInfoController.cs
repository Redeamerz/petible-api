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
        public async Task<UserInfo> Get(int id)
        {
            string guid = new string("af12a189-7e38-11ea-a63b-005056a73cc6");
            return await userInfoRepository.FindBy(guid);
        }

        // POST: api/UserInfo
        [HttpPost]
        public async void Post()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.id = "98549fc0-847c-11ea-a63b-005056a73cc6";
            userInfo.gender = false;
            userInfo.username = "randoname";
            await userInfoRepository.Save(userInfo);
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
