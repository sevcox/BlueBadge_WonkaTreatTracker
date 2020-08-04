using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TreatTracker.Models.CandyModels;
using TreatTracker.Services;

namespace TreatTracker.WebAPI.Controllers
{
    [Authorize]
    public class CandyController : ApiController
    {
        private CandyService CreateCandyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var candyService = new CandyService(userId);
            return candyService;
        }
        public IHttpActionResult Get()
        {
            CandyService candyService = CreateCandyService();
            var candies = candyService.GetCandies();
            return Ok(candies);
        }
        public IHttpActionResult Post(CandyCreate candy)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCandyService();

            if (!service.CreateCandy(candy))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            CandyService candyService = CreateCandyService();
            var candy = candyService.GetCandyById(id);
            return Ok(candy);
        }
        public IHttpActionResult Put(CandyEdit candy)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCandyService();

            if (!service.UpdateCandy(candy))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCandyService();

            if (!service.DeleteCandy(id))
                return InternalServerError();

            return Ok();
        }
    }
}
