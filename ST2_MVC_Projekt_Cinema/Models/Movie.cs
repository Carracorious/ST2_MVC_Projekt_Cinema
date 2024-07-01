﻿using System.ComponentModel.DataAnnotations;

namespace ST2_MVC_Projekt_Cinema.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
