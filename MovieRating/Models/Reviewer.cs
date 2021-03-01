using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Models
{
    public class Reviewer
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [Range(15,100)]
        public int Age { get; set; }
    }
}
