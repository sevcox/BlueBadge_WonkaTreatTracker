using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;

namespace TreatTracker.Models.GoldenTicketModels
{
    public class GoldenTicketEdit
    {
        public int TicketId { get; set; }
        public int CandyId { get; set; }
        public TypeOfPrize PrizeType { get; set; }
    }
}
