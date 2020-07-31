using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models
{
    public class Store_DrinkListItem
    {
        public int StoreId { get; set; }
        [Display(Name = "Name")]
        public string LocationName { get; set; }
        public int DrinkId { get; set; }
        [Display(Name = "Name")]
        public string TreatName { get; set; }
        public string Flavor { get; set; }
        public int Quantity { get; set; }
        
    }
}
