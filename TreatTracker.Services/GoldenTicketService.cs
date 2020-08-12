using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models.CandyModels;
using TreatTracker.Models.GoldenTicketModels;

namespace TreatTracker.Services
{
    public class GoldenTicketService
    {
        private readonly string _userName;
        public GoldenTicketService(string userName)
        {
            _userName = userName;
        }
        public bool CreateGoldenTicket(GoldenTicketCreate model)
        {
            var entity =
                new GoldenTicket()
                {
                    CandyId = model.CandyId,
                    PrizeType = model.PrizeType,
                    CreatedUtc = DateTimeOffset.UtcNow,
                    UserCreated = _userName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tickets.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }
        public IEnumerable<GoldenTicketListItem> GetGoldenTickets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Tickets
                    .Select(
                        e =>
                        new GoldenTicketListItem
                        {
                            CandyId = e.CandyId,
                            TicketId = e.TicketId,
                            CandyName = e.Candy.TreatName
                        }
                        );
                return query.ToArray();

            }
        }
        public GoldenTicketDetail GetGoldenTicketById(int ticketId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tickets
                        .Single(e => e.TicketId == ticketId);
                return
                    new GoldenTicketDetail
                    {
                        TicketId = entity.TicketId,
                        CandyId = entity.CandyId,
                        CandyName = entity.Candy.TreatName,
                        PrizeType = entity.PrizeType,
                        CreatedUtc = entity.CreatedUtc,
                        UserCreated = entity.UserCreated
                    };
            }
        }
        public CandyDetail GetCandyByGoldenTicketId(int goldenTicketId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Tickets
                    .Single(e => e.TicketId == goldenTicketId)
                    .Candy;
                return
                    new CandyDetail
                    {
                        CandyId = entity.CandyId,
                        TreatName = entity.TreatName,
                        CandyType = entity.CandyType,
                        Description = entity.Description,
                        SecretIngredient = entity.SecretIngredient,
                        Price = entity.Price,
                        Quantity = entity.Quantity,
                        CreatedUtc = entity.CreatedUtc,
                        UserCreated = entity.UserCreated,
                        ModifiedUtc = entity.ModifiedUtc,
                        UserModified = entity.UserModified
                    };
            }
        }
        public bool UpdateGoldenTicket(GoldenTicketEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tickets
                        .Single(e => e.TicketId == model.TicketId);
                entity.CandyId = model.CandyId;
                entity.PrizeType = model.PrizeType;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.UserModified = _userName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGoldenTicket(int ticketId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tickets
                        .Single(e => e.TicketId == ticketId);

                ctx.Tickets.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}