using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;

namespace TreatTracker.Models.GoldenTicketModels
{
   public  class GoldenTicketCreate
    {
        [Required]
        public int CandyId { get; set; }
        [Required]
<<<<<<< HEAD
        [Range(1, 3, ErrorMessage = "Please choose a number between 1 and 4.")]
        public TypeOfPrize PrizeType { get; set; }
        
        
=======
        [Range(1, 3, ErrorMessage = "Please choose a number between 1 and 3.")]
        public TypeOfPrize PrizeType { get; set; }
>>>>>>> 7d662ccdc7591c61bbf42bb2e37e180856459f2b
    }
}
