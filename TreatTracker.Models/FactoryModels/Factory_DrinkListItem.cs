using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;

namespace TreatTracker.Models
{
    public class Factory_DrinkListItem
    {
        public int FactoryId { get; set; }
        [Display(Name = "Name")]
        public string LocationName { get; set; }
        public int DrinkId { get; set; }
        [Display(Name = "Name")]
        public string TreatName { get; set; }
        public string Flavor { get; set; }
        public int Quantity { get; set; }
    }
}
