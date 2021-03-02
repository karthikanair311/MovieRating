using Microsoft.AspNetCore.Mvc;
using MovieRating.Data;
using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MovieRating.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class MovieController : Controller
    {
        private readonly MovieRatingContext _context;

        public MovieController(MovieRatingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewMovie()
        {
            var moviedetails = await _context.Movie.Include(c => c.MovieRatings)
               .Select(k => new MovieListViewModel { 
                
                   Title = k.Title,
                   Genre = k.Genre,
                   ReleaseDate = k.ReleaseDate,
                   AvgRating = k.MovieRatings.Average(l => l.RatingStar)
               })
               .ToListAsync();
           
            return View(moviedetails);
        }
       
        [HttpPost]
        public async Task<ActionResult> AddMovie(Movie model)
        {

            if (ModelState.IsValid)
            {
                Movie movie = new Movie
                {
                    
                    Title = model.Title,
                    Genre = model.Genre,
                    ReleaseDate = model.ReleaseDate
                    

                };
                _context.Add(movie);
                await _context.SaveChangesAsync();

            }
            else
            {
                return View("Index");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
