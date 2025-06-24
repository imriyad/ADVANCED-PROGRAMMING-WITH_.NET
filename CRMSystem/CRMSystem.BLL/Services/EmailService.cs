using CRMSystem.BLL.Interfaces;
using System;
using System.Net;
using System.Net.Mail;

namespace CRMSystem.BLL.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string subject, string body)
        {
            var from = "mahdikabirr@gmail.com";
            var password = "ktzfcebkplxwvtez";

            string fromTrimmed = from?.Trim();
            string toTrimmed = to?.Trim();

            if (string.IsNullOrEmpty(fromTrimmed))
                throw new ArgumentException("Sender email is empty or null.");

            if (string.IsNullOrEmpty(toTrimmed))
                throw new ArgumentException("Recipient email is empty or null.");

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromTrimmed, password),
                EnableSsl = true
            };

            var message = new MailMessage(fromTrimmed, toTrimmed, subject, body);
            client.Send(message);
        }

    }
}
