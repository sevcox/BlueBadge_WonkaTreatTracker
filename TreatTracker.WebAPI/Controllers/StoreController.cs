using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TreatTracker.Data;
using TreatTracker.Models.StoreModels;
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
        ///<summary>
        ///Returns a list of all stores selling our candy
        ///</summary>
        ///<param>Gets all Stores.</param>
        // GET api/values/5

        [HttpGet]
        public IHttpActionResult Get()
        {
            StoreService storeService = CreateStoreService();
            var stores = storeService.GetStores();
            return Ok(stores);
        }
        ///<summary>
        ///Returns the details of a specified store
        ///</summary>
        ///<param name="id">The store Id is needed.</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult GetStoreById(int id)
        {
            StoreService storeService = CreateStoreService();
            var store = storeService.GetStoreById(id);
            return Ok(store);

        }
        ///<summary>
        ///Returns a list of stores that are selling one a specific Wonka Candy
        ///</summary>
        ///<param name="candyId">Candy Id is need.</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult GetStoresByCandyId(int candyId)
        {
            StoreService storeService = CreateStoreService();
            var store = storeService.GetStoresByCandyId(candyId);
            return Ok(store);

        }
        ///<summary>
        ///Returns a list of stores that are selling one specific drink
        ///</summary>
        ///<param name="drinkId">Drink Id is needed.</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult GetStoresByDrinkId(int drinkId)
        {
            StoreService storeService = CreateStoreService();
            var store = storeService.GetStoresByDrinkId(drinkId);
            return Ok(store);

        }
        [HttpGet]
        public IHttpActionResult GetStoreInvoice([FromUri]int storeId,[FromBody]StoreShipping isShipping)
        {
            StoreService storeService = CreateStoreService();
            var invoice = storeService.GetStoreInvoice(storeId, isShipping);
            return Ok(invoice);
        }
    }
}
