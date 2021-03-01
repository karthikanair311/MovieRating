using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Models
{
    public class MovieListViewModel
    {
        
        public string Title { get; set; }
        public string Genre { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public double AvgRating { get; set; }

        //public ICollection<RatingViewModel> MovieRatings { get; set; }
    }
}
