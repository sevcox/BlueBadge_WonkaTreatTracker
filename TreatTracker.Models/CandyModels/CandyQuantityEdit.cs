using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.CandyModels
{
    public class CandyQuantityEdit
    {
        [Required]
        public int CandyId { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
