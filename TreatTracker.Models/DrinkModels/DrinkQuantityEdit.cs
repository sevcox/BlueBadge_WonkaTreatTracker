using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.DrinkModels
{
    public class DrinkQuantityEdit
    {
        public int DrinkId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
    }
}
