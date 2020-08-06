using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TreatTracker.Data;
using TreatTracker.Services;

namespace TreatTracker.WebAPI.Controllers
{
    public class StoreController : ApiController
    {
        [Authorize]
        private StoreService CreateStoreService()
        {
            var storeService = new StoreService();
            return storeService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            StoreService storeService = CreateStoreService();
            var stores = storeService.GetStores();
            return Ok(stores);
        }

        [HttpGet]
        public IHttpActionResult GetStoreById(int id)
        {
            StoreService storeService = CreateStoreService();
            var store = storeService.GetStoreById(id);
            return Ok(store);

        }
        [HttpGet]
        public IHttpActionResult GetStoresByCandyId(int candyId)
        {
            StoreService storeService = CreateStoreService();
            var store = storeService.GetStoresByCandyId(candyId);
            return Ok(store);

        }
        [HttpGet]
        public IHttpActionResult GetStoresByDrinkId(int drinkId)
        {
            StoreService storeService = CreateStoreService();
            var store = storeService.GetStoresByDrinkId(drinkId);
            return Ok(store);

        }
    }
}
