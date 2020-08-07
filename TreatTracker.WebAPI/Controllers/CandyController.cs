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
        ///<summary>
        ///Returns a list of all candies manufactured by Wonka Candy Enterprises
        ///</summary>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult Get()
        {
            CandyService candyService = CreateCandyService();
            var candies = candyService.GetCandies();
            return Ok(candies);
        }
        ///<summary>
        ///Creates a new candy
        ///</summary>
        // GET api/values/5
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
        ///<summary>
        ///Returns the details of a specific candy
        ///</summary>
        ///<param name="candyId">The Candy Id is needed</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult GetCandyById(int candyId)
        {
            CandyService candyService = CreateCandyService();
            var candy = candyService.GetCandyById(candyId);
            return Ok(candy);
        }
        ///<summary>
        ///Returns a list of candies that are manufactured at a specific factory
        ///</summary>
        ///<param name="factoryId">The Factory Id is needed</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult GetCandiesByFactoryId(int factoryId)
        {
            CandyService candyService = CreateCandyService();
            var candy = candyService.GetCandiesByFactoryId(factoryId);
            return Ok(candy);
        }
        ///<summary>
        ///Returns a list of candies sold at a specific store
        ///</summary>
        ///<param name="storeId">The Store Id is needed</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult GetCandiesByStoreId(int storeId)
        {
            CandyService candyService = CreateCandyService();
            var candy = candyService.GetCandiesByStoreId(storeId);
            return Ok(candy);
        }
        ///<summary>
        ///Allows the user to update a specific candy
        ///</summary>
        // GET api/values/5
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
        ///<summary>
        ///Places a specific candy in a specified store
        ///</summary>
        ///<param name="candyId">The Candy Id is needed</param>
        // GET api/values/5
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
        ///<summary>
        ///Removes a candy from existence
        ///</summary>
        ///<param name="candyId">The Candy Id is needed</param>
        // GET api/values/5
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
