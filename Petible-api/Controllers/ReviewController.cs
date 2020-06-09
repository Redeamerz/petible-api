using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ReviewController : ControllerBase
    {
        IUnitOfWork uow = null;
        IReviewRepository reviewRepository = null;

        public ReviewController(IUnitOfWork uow, IReviewRepository reviewRepository)
        {
            this.uow = uow;
            this.reviewRepository = reviewRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await reviewRepository.ListAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Review review = await reviewRepository.FindById(id);
            if (review == null) return BadRequest();
            else return Ok(review);
        }

        [HttpPut]
        public async Task<IActionResult> Post([FromBody] Review review)
        {
            try
            {
                await reviewRepository.Save(review);
                await uow.Commit();
                return Created("petible.nl", review);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Review review)
        {
            await reviewRepository.Remove(review);
            await uow.Commit();
            return NoContent();
        }
    }
}
