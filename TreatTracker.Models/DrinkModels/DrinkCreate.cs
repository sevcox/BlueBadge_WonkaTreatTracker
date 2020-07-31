using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.DrinkModels
{
    public class DrinkCreate
    {
        public string TreatName { get; set; }
        public string Flavor { get; set; }
        public string Description { get; set; }
        public string SecretIngredient { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
