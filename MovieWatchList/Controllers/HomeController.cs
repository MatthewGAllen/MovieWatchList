using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieWatchList.Models;
using Microsoft.AspNetCore.Identity;
using MovieWatchList.Data;
using System.Net;
using MovieWatchList.Areas.Identity.Pages.Account;
using System.Security.Claims;
using System.Security;
using Microsoft.AspNetCore.Authentication;
using MovieWatchList.Utility;

namespace MovieWatchList.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly LoginModel _loginModel;
        
        public HomeController(SignInManager<IdentityUser> signInManager)//, LoginModel loginModel)
        {
            _signInManager = signInManager;
            //_loginModel = loginModel;
        }

        public IActionResult Index()
        {
            if(User.IsInRole(SD.EndUser))
            {
                return Redirect("~/MovieInfo/Index");
            }

            return View();
        }
        
        
        public async Task<IActionResult> Login(User login)
        {
            if (ModelState.IsValid)
            {
                if (login == null)
                {
                    return NotFound();
                }

                var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, lockoutOnFailure: true);
                if(result.Succeeded)
                {
                    Console.WriteLine("hooray");
                    return Redirect("~/MovieInfo/Index");
                }
                else
                {
                    return View(nameof(Index));
                }
            }
            return View(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
