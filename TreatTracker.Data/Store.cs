using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Data
{
    public class Store : Location
    {
        public Store()
        {
            this.Candies = new HashSet<Candy>();
            this.Drinks = new HashSet<Drink>();
        }
        [Key]
        public int StoreId { get; set; }
        [Required]
        public virtual ICollection<Candy> Candies { get; set; }
        [Required]
        public virtual ICollection<Drink> Drinks { get; set; }
    }
}
