using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST2_MVC_Projekt_Cinema.Models;
using ST2_Projekt_Cinema.Data;

namespace ST2_MVC_Projekt_Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index() 
        {
            var seances = _context.Seances.Include(s => s.Movie).Select(s => new SeanceViewModel
            {
                Seance = s,
                ReservationCount = _context.Reservations.Count(r => r.SeanceId == s.Id)
            }).ToList();
            return View(seances);
        }

        //Obsluga dodawania seansow
        public IActionResult Create()
        {
            ViewBag.MovieList = new SelectList(_context.Movies, "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Create(DateTime startTime, int movieId)
        {        
            if (!ModelState.IsValid)
                return View();

            Seances seance = new Seances()
            {
                StartTime = startTime.ToUniversalTime(),
                MovieId = movieId
            };

            _context.Add(seance);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        //Obsluga usuwania seansow
        public IActionResult Delete(int id)
        {
            var seance = _context.Seances.Find(id);

            return View(seance);
        }

        [HttpPost]
        public IActionResult Delete(int id, Seances seance)
        {
            if (seance == null)
                return RedirectToAction("Index", "Movies");

            _context.Seances.Remove(seance);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }       
    }
}

