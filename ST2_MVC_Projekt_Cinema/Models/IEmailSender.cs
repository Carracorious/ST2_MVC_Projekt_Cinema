namespace ST2_MVC_Projekt_Cinema.Models
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);  
    }
}
