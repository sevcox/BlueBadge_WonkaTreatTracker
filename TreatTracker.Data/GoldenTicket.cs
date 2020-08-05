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
        [ForeignKey("Candy")]
        public int CandyTicketId { get; set; }
        public virtual Candy Candy{ get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Required]
        [Display(Name = "Creator")]
        public string UserCreated { get; set; }

    }
}
