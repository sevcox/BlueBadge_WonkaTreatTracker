using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Models
{
    public class StoreDetail
    {
        public int StoreId { get; set; }
        [Display(Name = "Name")]
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
