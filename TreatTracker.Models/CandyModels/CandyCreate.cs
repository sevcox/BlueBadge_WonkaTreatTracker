using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;

namespace TreatTracker.Models.CandyModels
{
    public class CandyCreate
    {
        public string TreatName { get; set; }
        public TypeOfCandy CandyType { get; set; }
        public string Description { get; set; }
        public string SecretIngredient { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
