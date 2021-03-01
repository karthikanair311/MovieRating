using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Models
{
    public class Rating
    {
        [Key]
        public int RId { get; set; }
        [Display(Name = "Movie")]
        public Movie Movie { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        [Display(Name = "Reviewer")]
        public ReviewerDetails ReviewerDetails { get; set; }
        [ForeignKey("ReviewerDetails")]
        public int ReviewerId { get; set; }
        [Required]
        [Range(1, 5)]
        public int RatingStar { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string ReviewComment { get; set; }
       // public int RateCount { get; set; }



    }
}
