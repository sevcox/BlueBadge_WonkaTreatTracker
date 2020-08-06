using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TreatTracker.Data;
using TreatTracker.Models.CandyModels;
using TreatTracker.Models.StoreModels;
using TreatTracker.Services;

namespace TreatTracker.WebAPI.Controllers
{
    [Authorize]
    public class CandyController : ApiController
    {
        private CandyService CreateCandyService()
        {
            var userName = User.Identity.GetUserName();
            var candyService = new CandyService(userName);
            return candyService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            CandyService candyService = CreateCandyService();
            var candies = candyService.GetCandies();
            return Ok(candies);
        }
        [HttpPost]
        public IHttpActionResult PostANewCandy(CandyCreate candy)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCandyService();

            if (!service.CreateCandy(candy))
                return InternalServerError();

            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetCandyById(int candyId)
        {
            CandyService candyService = CreateCandyService();
            var candy = candyService.GetCandyById(candyId);
            return Ok(candy);
        }
        [HttpGet]
        public IHttpActionResult GetCandiesByFactoryId(int factoryId)
        {
            CandyService candyService = CreateCandyService();
            var candy = candyService.GetCandiesByFactoryId(factoryId);
            return Ok(candy);
        }
        [HttpGet]
        public IHttpActionResult GetCandiesByStoreId(int storeId)
        {
            CandyService candyService = CreateCandyService();
            var candy = candyService.GetCandiesByStoreId(storeId);
            return Ok(candy);
        }
        [HttpPut]
        public IHttpActionResult Put(CandyEdit candy)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCandyService();

            if (!service.UpdateCandy(candy))
                return InternalServerError();

            return Ok();
        }
        [HttpPut]
        public IHttpActionResult PutACandyWithAStore([FromUri] int candyId, [FromBody] OnlyStoreId store)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCandyService();

            if (!service.ConnectCandyWithStore(candyId,store))
                return InternalServerError();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteACandy(int candyId)
        {
            var service = CreateCandyService();

            if (!service.DeleteCandy(candyId))
                return InternalServerError();

            return Ok();
        }
    }
}
