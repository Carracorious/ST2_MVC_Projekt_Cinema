using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST2_MVC_Projekt_Cinema.Models;
using ST2_Projekt_Cinema.Data;

namespace ST2_MVC_Projekt_Cinema.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController (AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Movies.ToList());
        }

        //Obsluga dodawania nowych filmow
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Title, string Description)
        {
            if (!ModelState.IsValid)
                return View();

            Movie movie = new Movie()
            {
                Title = Title,
                Description = Description
            };

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        //Obsluga usuwania filmow
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(int id, Movie movie)
        {
            if (movie == null)
                return RedirectToAction("Index", "Movies");

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        //Obsluga edytowania informacji o filmie
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                return View(movie);

            _context.Movies.Update(movie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }          
    }
}
