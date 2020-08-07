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
        /// <summary>
        /// allows oompa loompa to create a candy
        /// </summary>
        /// <returns></returns>
        private GoldenTicketService CreateGoldenTicketService()
        {
            var userName = User.Identity.GetUserName();
            var goldenTicketService = new GoldenTicketService(userName);
            return goldenTicketService;
        }
        /// <summary>
        /// creates a new golden ticket
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <param name="TicketId"></param>
        /// <returns></returns>
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
        /// <param name="ticket"></param>
        /// <returns></returns>
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
    /// <param name="id"></param>
    /// <returns></returns>
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
