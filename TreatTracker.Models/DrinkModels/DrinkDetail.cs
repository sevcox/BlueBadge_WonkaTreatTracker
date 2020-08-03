using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.DrinkModels
{
    public class DrinkDetail
    {
        public int DrinkId { get; set; }
        public string TreatName { get; set; }
        public string Flavor { get; set; }
        public string Description { get; set; }
        public string SecretIngredient { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset? CreatedUtc { get; set; }
        [Display(Name = "Creator")]
        public string UserCreated { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        [Display(Name = "Editor")]
        public string UserModified { get; set; }
    }
}
