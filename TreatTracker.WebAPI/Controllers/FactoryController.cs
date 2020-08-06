using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TreatTracker.Services;

namespace TreatTracker.WebAPI.Controllers
{
    public class FactoryController : ApiController
    {
        [Authorize]
        private FactoryService CreateFactoryService()
        {
            var factoryService = new FactoryService();
            return factoryService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            FactoryService factoryService = CreateFactoryService();
            var factories = factoryService.GetFactories();
            return Ok(factories);
        }

        [HttpGet]
        public IHttpActionResult GetFactoryById(int id)
        {
            FactoryService factoryService = CreateFactoryService();
            var factory = factoryService.GetFactoryById(id);
            return Ok(factory);

        }

    }
}