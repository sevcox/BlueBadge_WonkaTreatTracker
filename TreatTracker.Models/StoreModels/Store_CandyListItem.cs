using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models
{
    public class Store_CandyListItem
    {
        public int StoreId { get; set; }
        [Display(Name = "Name")]
        public string LocationName { get; set; }
        public int CandyId { get; set; }
        [Display(Name = "Name")]
        public string TreatName { get; set; }
        public TypeOfCandy CandyType { get; set; }
        public int Quantity { get; set; }
      
    }
}
