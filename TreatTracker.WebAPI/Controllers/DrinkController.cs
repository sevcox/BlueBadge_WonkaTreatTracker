﻿using Microsoft.AspNet.Identity;
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
        [HttpGet]
        public IHttpActionResult Get()
        {
            DrinkService drinkService = CreateDrinkService();
            var drinks = drinkService.GetDrinks();
            return Ok(drinks);
        }
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
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            DrinkService drinkService = CreateDrinkService();
            var drink = drinkService.GetDrinkById(id);
            return Ok(drink);
        }
        [HttpGet]
        public IHttpActionResult GetDrinksByFactoryId(int factoryId)
        {
            DrinkService drinkService = CreateDrinkService();
            var drink = drinkService.GetDrinksByFactoryId(factoryId);
            return Ok(drink);
        }
        [HttpGet]
        public IHttpActionResult GetDrinksByStoreId(int storeId)
        {
            DrinkService drinkService = CreateDrinkService();
            var drink = drinkService.GetDrinksByStoreId(storeId);
            return Ok(drink);
        }
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
