using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace TreatTracker.Data
{
    public abstract class Treat : AutoDateTime
    {
        [Required]
        public string TreatName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SecretIngredient { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
