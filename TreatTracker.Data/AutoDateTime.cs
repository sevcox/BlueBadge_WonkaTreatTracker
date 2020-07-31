using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Data
{
    public abstract class AutoDateTime
    {
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset? DateCreated { get; set; }
        [Required]
        [Display(Name = "Creator")]
        public string UserCreated { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset? DateModified { get; set; }
        [Display(Name = "Editor")]
        public string UserModified { get; set; }
    }
}
