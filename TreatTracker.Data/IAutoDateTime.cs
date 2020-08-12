using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Data
{
    public interface IAutoDateTime
    {
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        DateTimeOffset? CreatedUtc { get; set; }
        [Required]
        [Display(Name ="UserCreated")]
        string UserCreated { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        DateTimeOffset? ModifiedUtc { get; set; }
        [Display(Name = "Editor")]
        string UserModified { get; set; }
    }
}
