using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TreatTracker.Models.DrinkModels;
using TreatTracker.Models.StoreModels;
using TreatTracker.Services;

namespace TreatTracker.WebAPI.Controllers
{
    [Authorize]
    public class DrinkController : ApiController
    {
        private DrinkService CreateDrinkService()
        {
            var userName = User.Identity.GetUserName();
            var drinkService = new DrinkService(userName);
            return drinkService;
        }
        ///<summary>
        ///Returns a list of all the beverages created in the wonka factories
        ///</summary>
        [HttpGet]
        public IHttpActionResult Get()
        {
            DrinkService drinkService = CreateDrinkService();
            var drinks = drinkService.GetDrinks();
            return Ok(drinks);
        }
        ///<summary>
        ///Creates a new drink for mass consumption
        ///</summary>
        [HttpPost]
        public IHttpActionResult Post(DrinkCreate drink)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDrinkService();

            if (!service.CreateDrink(drink))
                return InternalServerError();

            return Ok();
        }
        ///<summary>
        ///Returns the details of a specific drink
        ///</summary>
        ///<param name="id">The Drink Id is needed</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            DrinkService drinkService = CreateDrinkService();
            var drink = drinkService.GetDrinkById(id);
            return Ok(drink);
        }
        ///<summary>
        ///Returns a list of all drinks created at a specific factory
        ///</summary>
        ///<param name="factoryId">The factory Id is needed</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult GetDrinksByFactoryId(int factoryId)
        {
            DrinkService drinkService = CreateDrinkService();
            var drink = drinkService.GetDrinksByFactoryId(factoryId);
            return Ok(drink);
        }
        ///<summary>
        ///Returns a list of all the drinks sold at a specific store
        ///</summary>
        ///<param name="storeId">The Store Id is needed</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult GetDrinksByStoreId(int storeId)
        {
            DrinkService drinkService = CreateDrinkService();
            var drink = drinkService.GetDrinksByStoreId(storeId);
            return Ok(drink);
        }
        ///<summary>
        ///Allows the user to update a specific drink
        ///</summary>
        // GET api/values/5
        [HttpPut]
        public IHttpActionResult Put(DrinkEdit drink)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDrinkService();

            if (!service.UpdateDrink(drink))
                return InternalServerError();

            return Ok();
        }
        ///<summary>
        ///Places a cand with a specific store
        ///</summary>
        ///<param name="drinkId">The Drink Id is needed</param>
        // GET api/values/5
        [HttpPut]
        public IHttpActionResult PutADrinkWithAStore(int drinkId, [FromBody] OnlyStoreId model )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDrinkService();

            if (!service.ConnectDrinkWithStore(drinkId, model))
                return InternalServerError();

            return Ok();
        }
        ///<summary>
        ///Removes a Drink from existence
        ///</summary>
        ///<param name="id">The Drink Id is needed</param>
        // GET api/values/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateDrinkService();

            if (!service.DeleteDrink(id))
                return InternalServerError();

            return Ok();
        }
    }
}
