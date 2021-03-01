using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieRating.Data;
using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace MovieRating.Controllers
{
    public class RegisterUserController : Controller
    {
        private readonly MovieRatingContext _context;
        private readonly SignInManager<UserDetails> _signinManager;
        private readonly UserManager<UserDetails> _userManager ;

        public RegisterUserController(MovieRatingContext context, UserManager<UserDetails> userManager, SignInManager<UserDetails> signinManager)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                UserDetails user = new UserDetails
                {
                    UserName = model.Name,
                    Name = model.Name
                    //Email = model.Email,
                    //Password = model.Password,
                    //Mobile = model.Mobile

                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //ReviewerDetails r = new ReviewerDetails
                    //{
                    //    Age = model.Age,
                    //    UserId = user.Id,
                    //    Name = model.Name

                    //};
                    //_context.Add(r);
                    //await _context.SaveChangesAsync();
                    await _signinManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            else
            {
                return View("Index");
            }
            // return RedirectToAction("Index", "UserDetails");
            return View(model);
        }

        //[HttpGet]
        //public async Task<string> GetCurrentUserId()
        //{
        //    UserDetails usr = await GetCurrentUserAsync();
            
        //    return usr?.Id;
           
        //}

        //private Task<UserDetails> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
       
    
}
