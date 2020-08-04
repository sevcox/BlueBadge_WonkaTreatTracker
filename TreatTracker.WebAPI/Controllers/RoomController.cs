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
    [Authorize]
    public class RoomController : ApiController
    {

        private RoomService CreateRoomService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var roomService = new RoomService(userId);
            return roomService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            RoomService roomService = CreateRoomService();
            var room = roomService.GetRooms();
            return Ok(room);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            {
                RoomService roomService = CreateRoomService();
                var rooms = roomService.GetRoomById(id);
                return Ok(rooms);
            }
        }
        [HttpGet]
        public IHttpActionResult GetByCharacterId(int CharacterId)
        {
            RoomService roomService = CreateRoomService();
            var room = roomService.GetRoomsByCharacterId(CharacterId);
            return Ok(room);
        }
    }


}
