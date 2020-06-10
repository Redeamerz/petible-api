using Microsoft.AspNetCore.Mvc;
using Petible_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuirkController : ControllerBase
    {
        IUnitOfWork uow = null;
        IQuirkRepository quirkRepository = null;

        public QuirkController(IUnitOfWork uow, IQuirkRepository quirkRepository)
        {
            this.uow = uow;
            this.quirkRepository = quirkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await quirkRepository.ListAll());
        }
    }
}
