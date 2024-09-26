using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace articals.Code
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com") // Replace with your actual SMTP server // Use your SMTP server address  
            {
                Port = 587, // Port (e.g., 587 for TLS/STARTTLS)  
                Credentials = new NetworkCredential("gogo2161@gmail.com", "tqkmjmzuqbyiddkh"),//write username and password
                EnableSsl = true, // Enable SSL if required  
            };
            return smtpClient.SendMailAsync("gogo2161@gmail.com", email, subject, htmlMessage);
        }

    }

}
