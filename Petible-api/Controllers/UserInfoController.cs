using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await userInfoRepository.ListAll());
        }

        // GET: api/UserInfo/GUID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            UserInfo userinfo = await userInfoRepository.FindById(id);
            if (userinfo == null) return BadRequest();
            else return Ok(userinfo);
        }

        // POST: api/UserInfo
        [HttpPut]
        public async Task<IActionResult> Post([FromBody]UserInfo userInfo)
        {
            try
            {
                await userInfoRepository.Save(userInfo);
                await uow.Commit();
                return Created("petible.nl", userInfo.id);
            }
            catch
            {
                return BadRequest();
            }
            
            
        }
            
        // PUT: api/UserInfo/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] UserInfo userInfo)
        {
            await userInfoRepository.Remove(userInfo);
            await uow.Commit();
            return NoContent();
        }

    }
}
