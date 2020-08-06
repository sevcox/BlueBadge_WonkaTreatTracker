using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Data
{
    public enum TypeOfPrize
    {
        Cash =1,
        FactoryVisit,
        LifeTime_Supply_Of_Chocolate
    }
    public class GoldenTicket : IAutoDateTime
    {
        [Key]
        public int TicketId { get; set; }
        [Index(IsUnique =true)]
        [Required]
        public int CandyId { get; set; }
        [ForeignKey(nameof(CandyId))]
        public virtual Candy Candy {get;set;}
        public TypeOfCandy PrizeType { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset? CreatedUtc { get; set; }
        [Display(Name = "Creator")]
       public  string UserCreated { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
       public  DateTimeOffset? ModifiedUtc { get; set; }
        [Display(Name = "Editor")]
        public string UserModified { get; set; }
    }
}
