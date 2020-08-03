﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models.GoldenTicketModels;

namespace TreatTracker.Services
{
    public class GoldenTicketService
    {
        private readonly Guid _userId;
        public GoldenTicketService (Guid userId)
        {
            _userId = userId;
        }
        public bool CreateGoldenTicket(GoldenTicketCreate model)
        {
            var entity =
                new GoldenTicket()
                {
                   CandyName= model.CandyName,
                   CandyId = model.CandyId

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
                            CandyName = e.CandyName,
                            Quantity = e.Quantity
                        }

                        );
                return query.ToArray();

            }
        }

    }
}
