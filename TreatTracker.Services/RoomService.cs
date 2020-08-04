using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models.RoomModels;

namespace TreatTracker.Services
{
   public  class RoomService
    {
        private readonly Guid _userId;
        public RoomService(Guid userId)
        {
            _userId = userId;
        }
        public IEnumerable<RoomListItem> GetRooms()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Rooms
                    .Select(
                        e =>
                        new RoomListItem
                        {
                            RoomId = e.RoomId,
                            Theme = e.Theme
                        }
                        );
                return query.ToArray();
            }

        }
        public RoomDetails GetRoomById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rooms
                    .Single(e => e.RoomId == id);
                    return
                    new RoomDetails
                    {
                        FactoryId = entity.FactoryId,
                        RoomId = entity.RoomId,
                        Theme = entity.Theme,
                        Description= entity.Description


                    };
            }
           
        }
        public RoomDetails GetRoomsByCharacterId(int CharacterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters
                    .Single(e => e.CharacterId == CharacterId)
                    .Room;

                return
                new RoomDetails
                {
                    FactoryId = entity.FactoryId,
                    Description = entity.Description,
                    Theme = entity.Theme,
                    RoomId = entity.RoomId
                };

            }
        }

    }
}
