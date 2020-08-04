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
        [HttpGet]
        public IHttpActionResult Get()
        {
            CharacterService characterService = CreateCharacterService();
            var characters = characterService.GetCharacters();
            return Ok(characters);
        }
        [HttpGet]
        public IHttpActionResult Get(int roomId)
        {
            CharacterService characterService = CreateCharacterService();
            var character = characterService.GetCharacterByRoomId(roomId);
            return Ok(character);
        }
        [HttpGet]
        public IHttpActionResult GetCharacter (int Id)
        {
            CharacterService characterService = CreateCharacterService();
            var character = characterService.GetCharacterById(Id);
            return Ok(character);
        }
        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            CharacterService characterService = CreateCharacterService();
            var charactera = characterService.GetCharacterByName(name);
            return Ok(charactera);
        }
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
