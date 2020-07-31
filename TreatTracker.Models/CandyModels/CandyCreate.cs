using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;

namespace TreatTracker.Models.CandyModels
{
    public class CandyCreate
    {
        [Required]
        [MinLength(3, ErrorMessage = "No one will buy a treat with a name that short.")]
        [MaxLength(50, ErrorMessage = "That name is too long. No one has the time to say that.")]
        public string TreatName { get; set; }
        [Required]
        [Range(1, 4, ErrorMessage = "Please choose a number between 1 and 4.")]
        public TypeOfCandy CandyType { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "WOW! We get it! It's delicious. Use less characters.")]
        public string Description { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "A secret ingredient that short? Never heard of it! Add more characters")]
        [MaxLength(50, ErrorMessage = "That isn't an ingredient, that's a whole recipe. Use less characters.")]
        public string SecretIngredient { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Range(1, 100, ErrorMessage = "Price must be between $1 and $100.")]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
    }
}
