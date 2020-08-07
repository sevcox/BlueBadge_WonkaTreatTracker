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
        /// <summary>
        /// creates a new character
        /// </summary>
        /// <returns></returns>
        private CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var characterService = new CharacterService(userId);
            return characterService;
        }
       /// <summary>
       ///returns all charcters created
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            CharacterService characterService = CreateCharacterService();
            var characters = characterService.GetCharacters();
            return Ok(characters);
        }
        /// <summary>
        /// looks up all characters by there room id
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(int roomId)
        {
            CharacterService characterService = CreateCharacterService();
            var character = characterService.GetCharacterByRoomId(roomId);
            return Ok(character);
        }
        /// <summary>
        /// looks up characters by there id number
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetCharacter (int Id)
        {
            CharacterService characterService = CreateCharacterService();
            var character = characterService.GetCharacterById(Id);
            return Ok(character);
        }
        /// <summary>
        /// looks up character by there name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            CharacterService characterService = CreateCharacterService();
            var charactera = characterService.GetCharacterByName(name);
            return Ok(charactera);
        }
        /// <summary>
        /// deletes a charcter by there id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
