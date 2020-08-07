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
        ///<summary>
        ///Returns a list of all the rooms in a factory
        ///</summary>
        // GET api/values/
        [HttpGet]
        public IHttpActionResult Get()
        {
            RoomService roomService = CreateRoomService();
            var room = roomService.GetRooms();
            return Ok(room);
        }
        ///<summary>
        ///Returns the details of a specified room 
        ///</summary
        ///<param name="Id">RoomId is needed</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            {
                RoomService roomService = CreateRoomService();
                var rooms = roomService.GetRoomById(id);
                return Ok(rooms);
            }
        }
        ///<summary>
        ///Returns the details of a room that a specific character is in 
        ///</summary>
        ///<param name="characterId">FactoryId is needed</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult GetByCharacterId(int characterId)
        {
            RoomService roomService = CreateRoomService();
            var room = roomService.GetRoomsByCharacterId(characterId);
            return Ok(room);
        }
    }


}
