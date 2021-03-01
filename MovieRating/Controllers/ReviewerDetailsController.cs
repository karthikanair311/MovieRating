using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRating.Data;
using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Controllers
{
    public class ReviewerDetailsController : Controller
    {
        private readonly MovieRatingContext _context;

        public ReviewerDetailsController(MovieRatingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ViewReviewerDetails()
        {
            return View(await _context.ReviewerDetails.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddReviewerDetails(ReviewerDetails model)
        {

            if (ModelState.IsValid)
            {
                ReviewerDetails reviewerdetails = new ReviewerDetails
                {

                    Name = model.Name,
                    Age = model.Age


                };
                _context.Add(reviewerdetails);
                await _context.SaveChangesAsync();

            }
            else
            {
                return View("Index");
            }
            // return RedirectToAction("Index", "Home");
            return View(model);
        }
    }
}
