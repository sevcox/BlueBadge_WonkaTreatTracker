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
        /// <summary>
        /// able to create a new room inside of our factory
        /// </summary>
        /// <returns></returns>
        private RoomService CreateRoomService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var roomService = new RoomService(userId);
            return roomService;
        }
        /// <summary>
        /// returns all rooms inside of our factory
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            RoomService roomService = CreateRoomService();
            var room = roomService.GetRooms();
            return Ok(room);
        }
        /// <summary>
        /// returns the list of a room by its id number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            {
                RoomService roomService = CreateRoomService();
                var rooms = roomService.GetRoomById(id);
                return Ok(rooms);
            }
        }
        /// <summary>
        /// returns list of characters in each room.
        /// </summary>
        /// <param name="CharacterId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetByCharacterId(int characterId)
        {
            RoomService roomService = CreateRoomService();
            var room = roomService.GetRoomsByCharacterId(characterId);
            return Ok(room);
        }
    }


}
