using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TreatTracker.Models.GoldenTicketModels;
using TreatTracker.Services;

namespace TreatTracker.WebAPI.Controllers
{
    [Authorize]
    public class GoldenTicketController : ApiController
    {

        private GoldenTicketService CreateGoldenTicketService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var goldenTicketService = new GoldenTicketService(userId);
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
    }
}
