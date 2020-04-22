using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Petible_api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AnimalShelterController : ControllerBase
    { 
        // GET: api/AnimalShelter
        
        [HttpGet]
        public string Get()
        {
        return "test";
        }

        // GET: api/AnimalShelter/5
        [HttpGet("{id}")]
        public string Gets(int id)
        {
            return "value";
        }

        // POST: api/AnimalShelter
        [HttpPost]
        public void Posts([FromBody] string value)
        {
        }

        // PUT: api/AnimalShelter/5
        [HttpPut("{id}")]
        public void Puts(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Deletes(int id)
        {
        }
    }
}
