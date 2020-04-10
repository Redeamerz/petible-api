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
    public class UserInfoController : ControllerBase
    {
        private readonly IMapperSession session;

        public UserInfoController(IMapperSession session)
        {
            this.session = session;
        }
        // GET: api/UserInfo
        [HttpGet]
        public List<UserInfo> Get()
        {
            var userinfo = session.userInfo.ToList();
            return userinfo;
        }

        // GET: api/UserInfo/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
