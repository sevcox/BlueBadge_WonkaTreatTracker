using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.DrinkModels
{
    public class DrinkListItem
    {
        public int DrinkId { get; set; }
        public string TreatName { get; set; }
        public string Flavor { get; set; }
        public int Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset? DateCreated { get; set; }
        [Display(Name = "Creator")]
        public string UserCreated { get; set; }
    }
}
