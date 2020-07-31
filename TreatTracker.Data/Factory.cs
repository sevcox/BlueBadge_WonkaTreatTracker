using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TreatTracker.Data
{
    public class Factory : Location
    {
        public Factory()
        {
            this.Candies = new HashSet<Candy>();
            this.Drinks = new HashSet<Drink>();
            this.Characters = new HashSet<Character>();
        }

        [Key]
        public int FactoryId { get; set; }
        [Required]
        public string Manager { get; set; }
        [Required]
        public virtual ICollection<Candy> Candies { get; set; }
        [Required]
        public virtual ICollection<Drink> Drinks { get; set; }
        [Required]
        public virtual ICollection<Character> Characters{ get; set; }
    }
}
