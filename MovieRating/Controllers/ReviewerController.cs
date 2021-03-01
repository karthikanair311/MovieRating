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
    public class ReviewerController : Controller
    {
        private readonly MovieRatingContext _context;

        public ReviewerController(MovieRatingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewReviewer()
        {
            return View(await _context.Movie.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult> AddReviewer(Reviewer model)
        {

            if (ModelState.IsValid)
            {
                Reviewer reviewer = new Reviewer
                {

                    Name = model.Name,
                    Age = model.Age


                };
                _context.Add(reviewer);
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
