using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Data
{
    public class Drink : Treat
    {
        [Key]
        public int DrinkId { get; set; }
        [Required]
        public string Flavor { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Factory> Factories { get; set; }

        public Drink()
        {
            Stores = new HashSet<Store>();
            Factories = new HashSet<Factory>();
        }
    }
}
