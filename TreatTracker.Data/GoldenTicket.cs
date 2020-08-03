using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Data
{
    public class GoldenTicket
    {
        [Key]
        public int TicketId { get; set; }
        public string CandyName { get; set; }
        public int CandyId { get; set; }
        [ForeignKey(nameof(CandyId))]
        public virtual Candy Candy{ get; set; }

    }
}
