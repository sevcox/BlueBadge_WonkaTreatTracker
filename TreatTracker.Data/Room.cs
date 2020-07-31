using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Data
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        [Required]
        public string Theme { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey(nameof(FactoryId))]
        public virtual Factory Factory { get; set; } 
    }
}
