using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Data
{
    public class StoreCandy
    {
        [Key]
        public int StoreCandyId { get; set; }
        public int StoreId { get; set; }
        public int CandyId { get; set; }
        [ForeignKey(nameof(CandyId))]
        public virtual Candy Candy { get; set; }
        [ForeignKey(nameof(StoreId))]
        public virtual Store Store { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
