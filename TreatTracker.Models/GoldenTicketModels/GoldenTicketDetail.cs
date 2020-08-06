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
<<<<<<< HEAD
        public string TreatName { get; set; }
        [Display (Name = "date Created")]
        public DateTime CreatedUtc { get; set; }
        public TypeOfPrize PrizeType { get; set; }
=======
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset? CreatedUtc { get; set; }
        public string CandyName { get; set; }
        [Display(Name = "Creator")]
        public string UserCreated { get; set; }
        public TypeOfPrize PrizeType { get; set; }

>>>>>>> 7d662ccdc7591c61bbf42bb2e37e180856459f2b
    }
}
