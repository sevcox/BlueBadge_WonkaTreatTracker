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
        ///<summary>
        ///Creates a new golden ticket
        ///</summary>
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
        ///<summary>
        ///Returns a list of all the GoldenTickets in Circulation and what Candy and Prize they are associated with
        ///</summary>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult Get()
        {
            GoldenTicketService goldenTicketService = CreateGoldenTicketService();
            var ticket = goldenTicketService.GetGoldenTickets();
            return Ok(ticket);
        }
        ///<summary>
        ///Returns the details of a candy associated with a Golden Ticket
        ///</summary>
        ///<param name="ticketid">The GoldenTicket Id is needed</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult GetCandyByGoldenTicketId(int ticketId)
        {
            GoldenTicketService goldenTicketService = CreateGoldenTicketService();
            var ticket = goldenTicketService.GetCandyByGoldenTicketId(ticketId);
            return Ok(ticket);
        }
        ///<summary>
        ///Allows the user to update a golden ticket
        ///</summary>
        // GET api/values/5
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
        ///<summary>
        ///Removes a GoldenTicket from circulation
        ///</summary>
        ///<param name="id">The GoldenTicket Id is needed</param>
        // GET api/values/5
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
