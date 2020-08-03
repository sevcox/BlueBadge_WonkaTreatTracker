using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.RoomModels
{
    public class RoomDetails
    {
        public int FactoryId { get; set; }
        public int RoomId { get; set; }
        [Display (Name ="Room Theme")]
        public string Theme { get; set; }
        [Display (Name ="room description")]
        public string Description { get; set; }
    }
}
