using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TreatTracker.Services;

namespace TreatTracker.WebAPI.Controllers
{     ///<summary>
      ///Welcome my friends, welcome to my chocolate factory.
      ///</summary>
    public class FactoryController : ApiController
    {
        [Authorize]
        private FactoryService CreateFactoryService()
        {
            var factoryService = new FactoryService();
            return factoryService;
        }

        ///<summary>
        ///Returns a list of all factories that are associated with Wonka Candy Enterprises
        ///</summary>
        [HttpGet]
        public IHttpActionResult Get()
        {
            FactoryService factoryService = CreateFactoryService();
            var factories = factoryService.GetFactories();
            return Ok(factories);
        }
        ///<summary>
        ///Returns the details of a specific factory
        ///</summary>
        ///<param name="factoryId">FactoryId is needed</param>
        [HttpGet]
        public IHttpActionResult GetFactoryById(int factoryId)
        {
            FactoryService factoryService = CreateFactoryService();
            var factory = factoryService.GetFactoryById(factoryId);
            return Ok(factory);

        }
        /// <summary>
        /// Returns the details of a specific factory based upon it's candy Id.
        /// </summary>
        /// <param name="candyId">The Candy Id is required.</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetFactoryByCandyId(int candyId)
        {
            FactoryService factoryService = CreateFactoryService();
            var factory = factoryService.GetFactoryByCandyId(candyId);
            return Ok(factory);
        }
        /// <summary>
        /// Returns the details of a specific factory based upon it's drink Id.
        /// </summary>
        /// <param name="drinkId">The Drink Id is required.</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetFactoryByDrinkId(int drinkId)
        {
            FactoryService factoryService = CreateFactoryService();
            var factory = factoryService.GetFactoryByDrinkId(drinkId);
            return Ok(factory);
        }
    }
}