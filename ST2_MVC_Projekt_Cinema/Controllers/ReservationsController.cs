using Microsoft.AspNetCore.Mvc;
using ST2_MVC_Projekt_Cinema.Models;
using ST2_Projekt_Cinema.Data;

namespace ST2_MVC_Projekt_Cinema.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly AppDbContext _context;

        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int seanceId)
        {
            ViewBag.SeanceId = seanceId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int seanceId, int seatNumber)
        {
            var reservation = new Reservations
            {
                UserId = 1, 
                SeanceId = seanceId,
                SeatNumber = seatNumber,
                IsConfirmed = true
            };
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
