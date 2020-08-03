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
            this.CandyList = new HashSet<Candy>();
            this.DrinkList = new HashSet<Drink>();
        }
        [Key]
        public int StoreId { get; set; }
        [Required]
        public virtual ICollection<Candy> CandyList { get; set; }
        [Required]
        public virtual ICollection<Drink> DrinkList { get; set; }
    }
}
