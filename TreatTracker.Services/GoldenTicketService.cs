using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models.CandyModels;
using TreatTracker.Models.GoldenTicketModels;

//namespace TreatTracker.Services
//{
//    public class GoldenTicketService
//    {
//        private readonly Guid _userId;
//        public GoldenTicketService(Guid userId)
//        {
//            _userId = userId;
//        }
//        public bool CreateGoldenTicket(GoldenTicketCreate model)
//        {
//            var entity =
//                new GoldenTicket()
//                {
//                    //CandyId = model.CandyId,
//                    CreatedUtc = DateTimeOffset.Now,
//                    UserCreated = _userId.ToString()

//                };
//            using (var ctx = new ApplicationDbContext())
//            {
//                ctx.Tickets.Add(entity);
//                return ctx.SaveChanges() == 1;

//            }
//        }
//        public IEnumerable<GoldenTicketListItem> GetGoldenTickets()
//        {
//            using (var ctx = new ApplicationDbContext())
//            {
//                var query =
//                    ctx
//                    .Tickets
//                    .Select(
//                        e =>
//                        new GoldenTicketListItem
//                        {
//                           // CandyId = e.CandyId,
//                            TicketId = e.TicketId
//                        }

//                        );
//                return query.ToArray();

//            }
//        }
//        public GoldenTicketDetail GetTicketById(int ticketId)
//        {
//            using (var ctx = new ApplicationDbContext())
//            {
//                var entity =
//                    ctx
//                        .Tickets
//                        .Single(e => e.TicketId == ticketId);
//                return
//                    new GoldenTicketDetail
//                    {
//                        TicketId = entity.TicketId,
//                        //CandyId = entity.CandyId,
//                        CreatedUtc = entity.CreatedUtc,
//                        UserCreated = entity.UserCreated
//                    };
//            }
//        }
//        public CandyDetail GetCandyByGoldenTicketId(int goldenTicketId)
//        {
//            using (var ctx = new ApplicationDbContext())
//            {
//                var entity =
//                    ctx
//                    .Tickets
//                    .Single(e => e.TicketId == goldenTicketId)
//                    .Candy;
//                return
//                    new CandyDetail
//                    {
//                        CandyId = entity.CandyId,
//                        TreatName = entity.TreatName,
//                        CandyType = entity.CandyType,
//                        Description = entity.Description,
//                        SecretIngredient = entity.SecretIngredient,
//                        Price = entity.Price,
//                        Quantity = entity.Quantity,
//                        CreatedUtc = entity.CreatedUtc,
//                        UserCreated = entity.UserCreated,
//                        ModifiedUtc = entity.ModifiedUtc,
//                        UserModified = entity.UserModified
//                    };
//            }
//        }
//    }
//}
