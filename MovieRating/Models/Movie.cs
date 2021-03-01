using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Models
{
    public class Movie
    {   [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Genre { get; set;}
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public ICollection<Rating> MovieRatings { get; set; }
       


    }
}
