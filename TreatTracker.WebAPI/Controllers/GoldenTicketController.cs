using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TreatTracker.Data;
using TreatTracker.Models.GoldenTicketModels;
using TreatTracker.Services;

namespace TreatTracker.WebAPI.Controllers
{
    [Authorize]
    public class GoldenTicketController : ApiController
    {

        private GoldenTicketService CreateGoldenTicketService()
        {
            var userName = User.Identity.GetUserName();
            var goldenTicketService = new GoldenTicketService(userName);
            return goldenTicketService;
        }
        [HttpPost]
        public IHttpActionResult Post(GoldenTicketCreate ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateGoldenTicketService();
            if (!service.CreateGoldenTicket(ticket))
                return InternalServerError();
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            GoldenTicketService goldenTicketService = CreateGoldenTicketService();
            var ticket = goldenTicketService.GetGoldenTickets();
            return Ok(ticket);
        }
        [HttpGet]
        public IHttpActionResult GetCandyByGoldenTicketId(int TicketId)
        {
            GoldenTicketService goldenTicketService = CreateGoldenTicketService();
            var ticket = goldenTicketService.GetCandyByGoldenTicketId(TicketId);
            return Ok(ticket);
        }
        [HttpPut]
        public IHttpActionResult Put(GoldenTicketEdit ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGoldenTicketService();

            if (!service.UpdateGoldenTicket(ticket))
                return InternalServerError();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGoldenTicketService();

            if (!service.DeleteGoldenTicket(id))
                return InternalServerError();

            return Ok();
        }
    }
}
