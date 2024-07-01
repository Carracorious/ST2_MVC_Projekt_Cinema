using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST2_MVC_Projekt_Cinema.Models;
using ST2_Projekt_Cinema.Data;
using System.Diagnostics;

namespace ST2_MVC_Projekt_Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index() 
        {
            var showtimes = await _appDbContext.Seances.Include(s => s.Movie).ToListAsync();
            return View(showtimes);
        }

        

        /*public IActionResult Index()
        {
            return View();
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
        */
    }
}
