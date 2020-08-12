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
    /// <summary>
    /// Violet! You're turning violet! 
    /// </summary>
    [Authorize]
    public class CharacterController : ApiController
    {
        private CharacterService CreateCharacterService()
        {
            var characterService = new CharacterService();
            return characterService;
        }
       /// <summary>
       ///Returns all indentured servants employed
       /// </summary>
        [HttpGet]
        public IHttpActionResult Get()
        {
            CharacterService characterService = CreateCharacterService();
            var characters = characterService.GetCharacters();
            return Ok(characters);
        }
        /// <summary>
        /// Find all characters by there room id
        /// </summary>
        /// <param name="roomId">Room Id is required.</param>
        [HttpGet]
        public IHttpActionResult Get(int roomId)
        {
            CharacterService characterService = CreateCharacterService();
            var character = characterService.GetCharacterByRoomId(roomId);
            return Ok(character);
        }
        /// <summary>
        /// Find characters by there id number
        /// </summary>
        /// <param name="id">Character id is required.</param>
        [HttpGet]
        public IHttpActionResult GetCharacter (int id)
        {
            CharacterService characterService = CreateCharacterService();
            var character = characterService.GetCharacterById(id);
            return Ok(character);
        }
        /// <summary>
        /// looks up character by there name
        /// </summary>
        /// <param name="name">Character name is required</param>
        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            CharacterService characterService = CreateCharacterService();
            var charactera = characterService.GetCharacterByName(name);
            return Ok(charactera);
        }
        /// <summary>
        /// Indentured servant acting up? Fire them!!!!
        /// </summary>
        /// <param name="id">Character Id is required.</param>
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
