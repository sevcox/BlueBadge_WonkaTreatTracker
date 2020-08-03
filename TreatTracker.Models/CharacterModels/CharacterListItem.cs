using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.CharacterModels
{
    public class CharacterListItem
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        [Display(Name ="character's Weakness")]
        public string Weakness { get; set; }
    }
}
