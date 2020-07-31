using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;

namespace TreatTracker.Models.CandyModels
{
   public class CandyDetail
    {
        public int CandyId { get; set; }
        public string TreatName { get; set; }
        public TypeOfCandy CandyType { get; set; }
        public string Description { get; set; }
        public string SecretIngredient { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        [Display(Name = "Creator")]
        public string UserCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }
        [Display(Name = "Editor")]
        public string UserModified { get; set; }
    }
}
