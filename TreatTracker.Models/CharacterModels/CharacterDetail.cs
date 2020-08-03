using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models.CharacterModels
{
   public  class CharacterDetail
    {
        public int CharacterId { get; set; }
        [Display(Name ="Character Name")]
        public string Name { get; set; }
        public int Age { get; set; }
        [Display(Name ="Character's Weakness")]
        public string Weakness { get; set; }
        public int RoomId { get; set; }
    }
}
