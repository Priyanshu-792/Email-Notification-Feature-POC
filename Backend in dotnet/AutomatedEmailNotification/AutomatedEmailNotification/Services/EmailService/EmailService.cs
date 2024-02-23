
// Namespace declarations
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;

namespace AutomatedEmailNotification.Services.EmailService
{
    // Implementation of the IEmailService interface for sending emails
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        // Constructor to inject the IConfiguration dependency
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        // Method to send confirmation email
        public void SendConfirmationEmail(string toEmail)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailUsername"]));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = "Registration Successful!";
            email.Body = new TextPart(TextFormat.Html) 
            // Creating the email body with HTML format
        
            {
                Text = "<p>Thank you for registering to this website!</p>"
            };

            using var smtp = new SmtpClient();
            smtp.Connect(_config["EmailHost"], 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config["EmailUsername"], _config["EmailPassword"]);
            smtp.Send(email); // Sending the email
            smtp.Disconnect(true);
        }
    }
}






