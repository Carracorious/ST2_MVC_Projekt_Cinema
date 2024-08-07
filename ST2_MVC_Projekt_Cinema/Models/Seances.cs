﻿using System.ComponentModel.DataAnnotations;

namespace ST2_MVC_Projekt_Cinema.Models
{
    public class Seances
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
