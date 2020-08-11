using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.CandyModels
{
    public class CandyQuantityEdit
    {
        public int CandyId { get; set; }

        public int Quantity { get; set; }

        public int StoreId { get; set; }
    }
}
