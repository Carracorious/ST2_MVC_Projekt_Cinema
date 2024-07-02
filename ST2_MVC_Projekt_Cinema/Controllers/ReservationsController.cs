using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST2_MVC_Projekt_Cinema.Models;
using ST2_Projekt_Cinema.Data;
using System.ComponentModel.DataAnnotations;

namespace ST2_MVC_Projekt_Cinema.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailSender _emailSender;


        public ReservationsController(AppDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var reservations = _context.Reservations.Include(r => r.User).Include(r => r.Seance).ThenInclude(s => s.Movie).ToList();
            return View(reservations);
        }

        //Obsluga dodawania rezerwacji
        public IActionResult Create(int seanceId)
        {
            ViewBag.SeanceId = seanceId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(int seanceId, int seatNumber, int discount, string userName, string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
            {
                user = new Users
                {
                    Name = userName,
                    Email = userEmail,
                    IsEmployee = false
                };

                _context.Users.Add(user);
                _context.SaveChanges();
            }

            var reservation = new Reservations
            {
                UserId = user.Id,
                SeanceId = seanceId,
                SeatNumber = seatNumber,
                IsConfirmed = true,
                Discount = discount
            };

            var receiver = userEmail;
            var subject = "Rezerwacja";
            var message = $"Rezerwacja na seans: {seanceId} na miejscu: {seatNumber}. Zastosowano zniżkę: {discount} %.";

            _emailSender.SendEmailAsync(receiver, subject, message);


            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return RedirectToAction("Index", "Reservations");
        }

        //Obsluga usuwania seansow
        public IActionResult Delete(int id)
        {
            var reservation = _context.Reservations.Find(id);

            return View(reservation);
        }

        [HttpPost]
        public IActionResult Delete(int id, Reservations reservation)
        {
            if (reservation == null)
                return RedirectToAction("Index", "Reservations");

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            return RedirectToAction("Index", "Reservations");
        }
    }
}
