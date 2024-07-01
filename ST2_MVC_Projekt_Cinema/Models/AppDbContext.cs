using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ST2_MVC_Projekt_Cinema.Models;

namespace ST2_Projekt_Cinema.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Seances> Seances { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
