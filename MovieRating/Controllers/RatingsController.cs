using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRating.Data;
using MovieRating.Models;

namespace MovieRating.Controllers
{
    public class RatingsController : Controller
    {
        private readonly MovieRatingContext _context;

        public RatingsController(MovieRatingContext context)
        {

            _context = context;
        }

       

    public async Task<IActionResult> ViewRating()
        {
            
            var movieRatingContext = _context.Rating.Include(r => r.Movie).Include(r => r.ReviewerDetails);
            return View(await movieRatingContext.ToListAsync());
        }
        
        public IActionResult Index()
        {
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            ViewData["ReviewerId"] = new SelectList(_context.ReviewerDetails, "Id", "Id");
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> AddRating(Rating model)
        {

            if (ModelState.IsValid)
            {
                Rating rating = new Rating
                {
                    MovieId = model.MovieId,
                    ReviewerId = model.ReviewerId,
                    RatingStar = model.RatingStar,
                    ReviewComment = model.ReviewComment
                    


                };
                _context.Add(rating);
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
