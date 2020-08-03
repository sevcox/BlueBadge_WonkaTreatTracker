using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int? FactoryId { get; set; }
        [ForeignKey(nameof(FactoryId))]
        public virtual Factory Factory { get; set; }
        public Drink()
        {
            Stores = new HashSet<Store>();
        }
    }
}
