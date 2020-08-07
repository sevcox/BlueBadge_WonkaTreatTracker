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
    public class CharacterController : ApiController
    {
        private CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var characterService = new CharacterService(userId);
            return characterService;
        }
        ///<summary>
        ///Returns a list of all the characters with in our factory
        ///</summary>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult Get()
        {
            CharacterService characterService = CreateCharacterService();
            var characters = characterService.GetCharacters();
            return Ok(characters);
        }
        ///<summary>
        ///Returns the Details of a character in a specific room
        ///</summary>
        ///<param name="id">The Room Id is needed</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult Get(int roomId)
        {
            CharacterService characterService = CreateCharacterService();
            var character = characterService.GetCharacterByRoomId(roomId);
            return Ok(character);
        }
        ///<summary>
        ///Returns the details about a specific character
        ///</summary>
        ///<param name="id">The Character Id is needed</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult GetCharacter (int id)
        {
            CharacterService characterService = CreateCharacterService();
            var character = characterService.GetCharacterById(id);
            return Ok(character);
        }
        ///<summary>
        ///Return the details of a given character associated with a specific name
        ///</summary>
        ///<param name="name">The specific Character Name is needed</param>
        // GET api/values/5
        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            CharacterService characterService = CreateCharacterService();
            var charactera = characterService.GetCharacterByName(name);
            return Ok(charactera);
        }
        ///<summary>
        ///Eliminates a character from the factory those weaklings
        ///</summary>
        ///<param name="id">The Character Id is needed</param>
        // GET api/values/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var acharacter = CreateCharacterService();
            if (!acharacter.DeleteCharacter(id))
                return InternalServerError();
            return Ok();
        }

    }
}
