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
    /// <summary>
    /// Oh I've got a golden ticket!!!! 
    /// </summary>
    [Authorize]
    public class GoldenTicketController : ApiController
    {
        private GoldenTicketService CreateGoldenTicketService()
        {
            var userName = User.Identity.GetUserName();
            var goldenTicketService = new GoldenTicketService(userName);
            return goldenTicketService;
        }
        /// <summary>
        /// creates a new golden ticket
        /// </summary>
        /// <param name="ticket">Please enter in all required information</param>
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
        /// <summary>
        /// returns all of the created golden tickets
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get()
        {
            GoldenTicketService goldenTicketService = CreateGoldenTicketService();
            var ticket = goldenTicketService.GetGoldenTickets();
            return Ok(ticket);
        }
        /// <summary>
        /// returns Golden ticket by its Id number
        /// </summary>
        /// <param name="ticketId">Golden Ticket Id is required.</param>
        [HttpGet]
        public IHttpActionResult GetCandyByGoldenTicketId(int ticketId)
        {
            GoldenTicketService goldenTicketService = CreateGoldenTicketService();
            var ticket = goldenTicketService.GetCandyByGoldenTicketId(ticketId);
            return Ok(ticket);
        }
        /// <summary>
        /// allows us to edit a golden ticket
        /// </summary>
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

    /// <summary>
    /// able to delete a golden ticket.
    /// </summary>
    /// <param name="id">Golden Ticket Id is required.</param>
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
