using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatTracker.Data
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Weakness { get; set; }
        public int RoomId { get; set; }
        [ForeignKey(nameof(RoomId))]
        public virtual Room Room { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                if (DateOfBirth == new DateTime())
                {
                    return 9001;
                }
                TimeSpan ageSpan = DateTime.Now - DateOfBirth;
                double totalAgeInYear = ageSpan.TotalDays / 365.25;
                return Convert.ToInt32(Math.Floor(totalAgeInYear));
            }
        }

    }
}
