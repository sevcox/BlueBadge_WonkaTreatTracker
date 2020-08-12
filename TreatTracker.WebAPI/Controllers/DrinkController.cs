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
    /// <summary>
    /// Candy is dandy but liquor is quicker!
    /// </summary>
    [Authorize]
    public class DrinkController : ApiController
    {
        private DrinkService CreateDrinkService()
        {
            var userName = User.Identity.GetUserName();
            var drinkService = new DrinkService(userName);
            return drinkService;
        }
        /// <summary>
        /// View all Fizzy Lifting Drinks created in Wonka Candy Enterprise.
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get()
        {
            DrinkService drinkService = CreateDrinkService();
            var drinks = drinkService.GetDrinks();
            return Ok(drinks);
        }
        /// <summary>
        /// Create a new drink entry for your factory after inventory was counted.
        /// </summary>
        /// <param name="drink">Make sure to enter in all the required details when creating a drink entry. Your Factory Id, username, and today's date will be automatically added to the entry.</param>
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
        /// <summary>
        /// Find a specific fizzing lifting drink entry.
        /// </summary>
        /// <param name="id">The Drink Id is required.</param>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            DrinkService drinkService = CreateDrinkService();
            var drink = drinkService.GetDrinkById(id);
            return Ok(drink);
        }
        /// <summary>
        /// Find a specific fizzy lifting drink entry by factory location.
        /// </summary>
        /// <param name="factoryId">The Factory Id is required.</param>
        [HttpGet]
        public IHttpActionResult GetDrinksByFactoryId(int factoryId)
        {
            DrinkService drinkService = CreateDrinkService();
            var drink = drinkService.GetDrinksByFactoryId(factoryId);
            return Ok(drink);
        }
        /// <summary>
        /// Find a specific Fizzy Lifting Drink entry by store location.
        /// USE THIS WHEN: *RECALL* or *SECRET INGREDIENT BREACH*
        /// </summary>
        /// <param name="storeId">The Store Id is required.</param>
        [HttpGet]
        public IHttpActionResult GetDrinksByStoreId(int storeId)
        {
            DrinkService drinkService = CreateDrinkService();
            var drink = drinkService.GetDrinksByStoreId(storeId);
            return Ok(drink);
        }
        /// <summary>
        /// Made a mistake on a drink entry? No worries... Wonka has your back. Edit a candy here.
        /// </summary>
        /// <param name="drink">Make sure to enter in all the required details when editing a drink entry. Your username and today's date will automatically be added to the modification.</param>
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
        /// <summary>
        /// Selling drinks to a store.
        /// </summary>
        /// <param name="drinkId">Remember to enter in the drink id that you are selling.</param>
        /// <param name="storeId">Enter in the store that you are selling to.</param>
        [HttpPut, Route("api/Drink/SellingDrinks")]
        public IHttpActionResult PutACandyWithAStore([FromUri]int drinkId, [FromBody]OnlyStoreId storeId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDrinkService();

            if (!service.ConnectDrinkWithStore(drinkId, storeId))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Sold out or discontinued a fizzy lifting drink? This is the place for you! 
        /// </summary>
        /// <param name="id">The Drink Id is required.</param>
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
