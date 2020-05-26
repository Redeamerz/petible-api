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
    public class ReviewsController : ControllerBase
    {
        IUnitOfWork uow = null;
        IReviewRepository reviewRepository = null;

        public ReviewsController(IUnitOfWork uow, IReviewRepository reviewRepository)
        {
            this.uow = uow;
            this.reviewRepository = reviewRepository;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await reviewRepository.ListAll());
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Reviews reviews = await reviewRepository.FindById(id);
            if (reviews == null) return BadRequest();
            else return Ok(reviews);
        }

        // PUT: api/Reviews/5
        [HttpPut]
        public async Task<IActionResult> Post([FromBody] Reviews reviews)
        {
            try
            {
                await reviewRepository.Save(reviews);
                await uow.Commit();
                return Created("petible.nl", reviews.id);
            }
            catch
            {
                return BadRequest();
            }


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Reviews reviews)
        {
            await reviewRepository.Remove(reviews);
            await uow.Commit();
            return NoContent();
        }
    }
}
