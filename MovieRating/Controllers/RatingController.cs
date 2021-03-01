using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRating.Data;
using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Controllers
{
    public class RatingController : Controller
    {
        private readonly MovieRatingContext _context;

        public RatingController(MovieRatingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewRating()
        {
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            ViewData["ReviewerId"] = new SelectList(_context.ReviewerDetails, "Id", "Name");
            return View(await _context.Rating.ToListAsync());
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RId,MovieId,ReviewerId,RatingStar,ReviewComment")] Rating ratingMov)
        {
            if (id != ratingMov.RId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ratingMov);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewerDetailsExists(ratingMov.RId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "MovieId", ratingMov.MovieId);
            ViewData["ReviewerId"] = new SelectList(_context.ReviewerDetails, "ReviewerId", "ReviewerId", ratingMov.ReviewerId);
            return View(ratingMov);
        }

        private bool ReviewerDetailsExists(object id)
        {
            throw new NotImplementedException();
        }
        /*
[HttpPost]
public async Task<ActionResult> AddRating(Rating model)
{

   if (ModelState.IsValid)
   {
       Rating rating = new Rating
       {

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
*/

    }
}
