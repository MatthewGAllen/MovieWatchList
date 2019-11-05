using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWatchList.Data;
using MovieWatchList.Models;
using MovieWatchList.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MovieWatchList.Controllers
{
    [Authorize(Roles = SD.EndUser)]
    public class MovieInfoController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _manager;
        public MovieInfoController(ApplicationDbContext db, UserManager<IdentityUser> manager)
        {
            _db = db;
            _manager = manager;
        }
        
        //GET-Index
        public async Task<IActionResult> Index()
        {
            var movies = await _db.MovieInfo.ToListAsync();
            return View(movies);
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieInfo movieInfo)
        {
            if(ModelState.IsValid)
            {
                IdentityUser manager = await _manager.GetUserAsync(User);
                movieInfo.UserId = manager.Id;
                _db.Add(movieInfo);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieInfo);
        }

        //GET-Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var movieInfo = await _db.MovieInfo.FindAsync(id);
            if(movieInfo==null)
            {
                return NotFound();
            }
            return View(movieInfo);
        }


        //POST-Edit-fixed?
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieInfo movieInfo)
        {


            if(ModelState.IsValid)
            {
                IdentityUser manager = await _manager.GetUserAsync(User);
                movieInfo.UserId = manager.Id;
                _db.Update(movieInfo);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieInfo);
        }

        //GET-Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movieInfo = await _db.MovieInfo.FindAsync(id);
            if (movieInfo == null)
            {
                return NotFound();
            }
            return View(movieInfo);
        }

        //POST-Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var category = await _db.MovieInfo.FindAsync(id);
            if (category == null)
            {
                return View();
            }
            _db.MovieInfo.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //GET-Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movieInfo = await _db.MovieInfo.FindAsync(id);
            if (movieInfo == null)
            {
                return NotFound();
            }
            return View(movieInfo);
        }
    }
}