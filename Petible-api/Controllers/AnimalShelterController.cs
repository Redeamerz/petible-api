using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Petible_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AnimalShelterController : ControllerBase
    {
        // GET: api/AnimalShelter
        [HttpGet]
        public IEnumerable<string> Gets()
        {
            return new string[] { "value1", "value2" };
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
