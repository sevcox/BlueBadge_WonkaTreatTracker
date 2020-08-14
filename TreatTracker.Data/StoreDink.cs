using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Data
{
    public class StoreDink
    {
        [Key]
        public int StoreDrink { get; set; }
        public int StoreId { get; set; }

        public int DrinkId { get; set; }

        public virtual Drink Drink { get; set; }

        public virtual Store Store { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
