using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWatchList.Data;
using MovieWatchList.Models;

namespace MovieWatchList.Controllers
{
    public class MovieInfoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieInfoController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        //GET-Index
        public async Task<IActionResult> Index()
        {
            return View(await _db.MovieInfo.ToListAsync());
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
            var movieInfo = _db.MovieInfo.FindAsync(id);
            if(movieInfo==null)
            {
                return NotFound();
            }
            return View(movieInfo);
        }
    }
}