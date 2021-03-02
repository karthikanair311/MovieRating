using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
   // [Authorize]
    public class UserDetailsController : Controller
    {
       
        private readonly MovieRatingContext _context;
        private readonly SignInManager<UserDetails> _signinManager;

        public UserDetailsController(MovieRatingContext context, SignInManager<UserDetails> signinManager)
        {
            _context = context;
            _signinManager = signinManager;
        }

      //  [AllowAnonymous]
        public IActionResult Index()
        {
          
            if (_signinManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

       // [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
               var a = await _signinManager.PasswordSignInAsync(model.Name, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (a.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }


            }
            else
            {
                return View("Index");
            }
            return RedirectToAction("Index", "Home");
        }
        
        public async Task<IActionResult> LogoutAsync()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("FirstViewPage", "Home");
        }
    }
}
