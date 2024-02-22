﻿
/*using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
namespace AutomatedEmailNotification.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config) { 
         _config = config;
        }
        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = "Registraion successful";
              email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
              {
                  Text = request.Body
              };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}

*/





using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;

namespace AutomatedEmailNotification.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendConfirmationEmail(string toEmail)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailUsername"]));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = "Registration Confirmation";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = "Thank you for registering!"
            };

            using var smtp = new SmtpClient();
            smtp.Connect(_config["EmailHost"], 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config["EmailUsername"], _config["EmailPassword"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
