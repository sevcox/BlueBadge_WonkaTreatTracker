using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.CandyModels
{
    public class CandyEdit
    {
        public int CandyId { get; set; }
        public string TreatName { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset? DateCreated { get; set; }
        [Display(Name = "Creator")]
        public string UserCreated { get; set; }
    }
}
