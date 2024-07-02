
using System.Net;
using System.Net.Mail;

namespace ST2_MVC_Projekt_Cinema.Models
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail =  "konkraw67150@gmail.com";
            var password = "uvvr swjr lgob vlbs";
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, password)
            };
            return client.SendMailAsync(new MailMessage(from:mail,to:email,subject,message));
            
        }
    }
}
