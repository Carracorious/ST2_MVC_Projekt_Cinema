using System.ComponentModel.DataAnnotations;

namespace ST2_MVC_Projekt_Cinema.Models
{
    public class Reservations
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SeanceId { get; set; }
        public int SeatNumber { get; set; }
        public bool IsConfirmed { get; set; }
        public double Discount { get; set; }
        public Users User { get; set; }
        public Seances Seance { get; set; }
    }
}
