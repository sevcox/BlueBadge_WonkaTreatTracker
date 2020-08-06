﻿using Microsoft.AspNet.Identity;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var storeService = new StoreService(userId);
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
        
        


    }
}
