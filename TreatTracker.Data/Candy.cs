using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Data
{
    public enum TypeOfCandy
    {
        Chocolate = 1,
        Gummy,
        Hard,
        ChewingGum
    }
    public class Candy : Treat
    {
        [Key]
        public int CandyId { get; set; }
        [Required]
        public TypeOfCandy CandyType { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Factory> Factories { get; set; }

        public Candy()
        {
            Stores = new HashSet<Store>();
            Factories = new HashSet<Factory>();
        }
    }
}
