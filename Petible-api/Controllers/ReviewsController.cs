﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petible_api.Interfaces;
using Petible_api.Models;
using Renci.SshNet.Messages.Transport;

namespace Petible_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        IReviewsRepository reviewsRepository;
        IUnitOfWork uow;

        public ReviewsController(IReviewsRepository reviewsRepository, IUnitOfWork uow)
        {
            this.reviewsRepository = reviewsRepository;
            this.uow = uow;
        }

        // GET: api/Matches
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await reviewsRepository.ListAll());
        }

        // GET: api/Matches/5
        //TODO authenticate
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Matches matches = await reviewsRepository.FindById(id);
            if (matches == null) return BadRequest();
            else return Ok(matches);
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<IActionResult> PostsAsync([FromBody] Reviews reviews)
        {
            throw new NotImplementedException("Nog geen auth");
            try
            {
                await reviewsRepository.Save(reviews);
                await uow.Commit();
                return Created("petible.nl/reviews", reviews.id);
            }
            catch
            {
                return BadRequest();
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletes(Reviews review)
        {
            throw new NotImplementedException("Er is nog geen auth");
            try
            {
                await reviewsRepository.Remove(review);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
