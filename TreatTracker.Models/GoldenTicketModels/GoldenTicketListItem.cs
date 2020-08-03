using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.GoldenTicketModels
{
    public class GoldenTicketListItem
    {
        public int CandyId { get; set; }
        [Display(Name ="Name")]
        public string CandyName { get; set; }
        public int Quantity { get; set; }
    }
}
