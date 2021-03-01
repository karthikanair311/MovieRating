using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name length can't be more than 15")]
        //[StringLength(15, ErrorMessage = "Name length can't be more than 15.")]
        public string Name { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [NotMapped] // Does not effect with your database
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
       // public int Age { get; internal set; }
    }
}
