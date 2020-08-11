using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.StoreModels
{
   public class StoreInvoice
    {
        public int StoreId { get; set; }
        public int AmountofTreats { get; set; }
        public decimal? TotalCost { get; set; }
    }
}
