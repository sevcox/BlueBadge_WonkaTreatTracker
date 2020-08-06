using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;

namespace TreatTracker.Models.GoldenTicketModels
{
    public class GoldenTicketDetail
    {
        public int TicketId { get; set; }
        public int CandyId { get; set; }
        public string TreatName { get; set; }
        [Display (Name = "date Created")]
        public DateTime CreatedUtc { get; set; }
        public TypeOfPrize PrizeType { get; set; }
    }
}
