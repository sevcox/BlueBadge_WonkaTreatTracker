using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models.CharacterModels;

namespace TreatTracker.Services
{
   public  class CharacterService
    {
        private readonly Guid _userId;
        public CharacterService(Guid userId)
        {
            _userId = userId;
        }
        public IEnumerable<CharacterListItem> GetCharacters()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Characters
                    .Select(
                        e =>
                        new CharacterListItem
                        {
                            RoomId = e.RoomId,
                            Name = e.Name,
                            Weakness = e.Weakness

                        }
                        );
                return query.ToArray();
            }
        }
        public CharacterDetail GetCharacterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters
                    .Single(e => e.CharacterId == id);
                return
                    new CharacterDetail
                    {
                        CharacterId = entity.CharacterId,
                        Age = entity.Age,
                        Weakness = entity.Weakness,
                        Name = entity.Name,
                        RoomId = entity.RoomId
                    };
            }
        }
        
        public CharacterDetail GetCharacterByRoomId(int roomId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                    .Characters
                    .Single(e => e.RoomId == roomId);
                return
                    new CharacterDetail
                    {
                        CharacterId = entity.CharacterId,
                        Age = entity.Age,
                        Name = entity.Name,
                        RoomId = entity.RoomId,
                        Weakness = entity.Weakness

                    };
            }
        }
        public ICollection <CharacterListItem> GetCharactersByFactory(int factoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Factories
                    .Where(e=> e.FactoryId ==factoryId )
                    
                    .Select(
                        e =>
                        new CharacterListItem
                        {
                            Name = e.Name,
                            Weakness = e.Weakness,
                            RoomId = e.RoomId
                        }
                        );
                return query.ToArray();
                    
                
                    
                

                
                   

            }
        }
        public CharacterDetail GetCharacterByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters
                    .Single(e => e.Name == name);
                return
                    new CharacterDetail
                    {
                        CharacterId = entity.CharacterId,
                        Age = entity.Age,
                        Weakness = entity.Weakness,
                        Name = entity.Name,
                        RoomId = entity.RoomId
                    };
            }
        }
        public bool DeleteCharacter(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters
                    .Single(e => e.CharacterId == characterId);
                    ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }

}
