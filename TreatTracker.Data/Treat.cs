using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace TreatTracker.Data
{
    public abstract class Treat : IAutoDateTime
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
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset? CreatedUtc { get; set; }
        [Required]
        [Display(Name = "Creator")]
        public string UserCreated { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        [Display(Name = "Editor")]
        public string UserModified { get; set; }
    }
}
