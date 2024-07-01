using System.ComponentModel.DataAnnotations;

namespace ST2_MVC_Projekt_Cinema.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsEmployee { get; set; }
    }
}
