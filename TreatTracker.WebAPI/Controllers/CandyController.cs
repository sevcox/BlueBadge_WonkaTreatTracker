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
    /// <summary>
    /// Candy invention, my dear friends, is 93% perspiration, 6% electricity, 4% evaporation, and 2% butter scotch ripple.
    /// </summary>
    [Authorize]
    public class CandyController : ApiController
    {
        private CandyService CreateCandyService()
        {
            var userName = User.Identity.GetUserName();
            var candyService = new CandyService(userName);
            return candyService;
        }
        /// <summary>
        /// View all Candies created in Wonka Candy Enterprise.
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get()
        {
            CandyService candyService = CreateCandyService();
            var candies = candyService.GetCandies();
            return Ok(candies);
        }
        /// <summary>
        /// Create a new candy entry for your factory after inventory was counted.
        /// </summary>
        /// <param name="candy">Make sure to enter in all the required details when creating a candy entry. Your Factory Id, username, and today's date will be automatically added to the entry.</param>
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
        /// <summary>
        /// Find a specific Wonka candy entry.
        /// </summary>
        /// <param name="candyId">The Candy Id is required.</param>
        [HttpGet]
        public IHttpActionResult GetCandyById(int candyId)
        {
            CandyService candyService = CreateCandyService();
            var candy = candyService.GetCandyById(candyId);
            return Ok(candy);
        }
        /// <summary>
        /// Find a specific Wonka candy entry by factory location.
        /// </summary>
        /// <param name="factoryId">The Factory Id is required.</param>
        [HttpGet]
        public IHttpActionResult GetCandiesByFactoryId(int factoryId)
        {
            CandyService candyService = CreateCandyService();
            var candy = candyService.GetCandiesByFactoryId(factoryId);
            return Ok(candy);
        }
        /// <summary>
        /// Find a specific Wonka candy entry by store location.
        /// USE THIS WHEN: *RECALL* or *SECRET INGREDIENT BREACH*
        /// </summary>
        /// <param name="storeId">The Store Id is required.</param>
        [HttpGet]
        public IHttpActionResult GetCandiesByStoreId(int storeId)
        {
            CandyService candyService = CreateCandyService();
            var candy = candyService.GetCandiesByStoreId(storeId);
            return Ok(candy);
        }
        /// <summary>
        /// Made a mistake on a candy entry? No worries... Wonka has your back. Edit a candy here.
        /// </summary>
        /// <param name="candy">Make sure to enter in all the required details when editing a candy entry. Your username and today's date will automatically be added to the modification.</param>
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
        /// <summary>
        /// Selling candy to a store.
        /// </summary>
        /// <param name="candyId">This will direct you to the specific candy's selling page.</param>
        /// <param name="store">Remember to enter in the Store that you are selling to.</param>
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
        /// <summary>
        /// Sold out or discontinued a candy? This is the place for you! 
        /// </summary>
        /// <param name="candyId">The Candy Id is required.</param>
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
