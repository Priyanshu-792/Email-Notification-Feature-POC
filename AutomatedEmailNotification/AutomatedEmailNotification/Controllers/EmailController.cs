/*using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net.Mail;



namespace AutomatedEmailNotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService) {

            _emailService = emailService;       
        } 


        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);
            return Ok();


        }
    }
}
*/


//remove this code
/*       var email = new MimeMessage();  
email.From.Add(MailboxAddress.Parse("ahmad.hagenes@ethereal.email"));
email.To.Add(MailboxAddress.Parse("ahmad.hagenes@ethereal.email"));
email.Subject = "Test Email Subject";
email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
{
    Text = body
};
using var smtp = new MailKit.Net.Smtp.SmtpClient();
smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
smtp.Authenticate("ahmad.hagenes@ethereal.email", "cHv9cXpuDhzgHDAfct");
smtp.Send(email);
smtp.Disconnect(true); */





using Microsoft.AspNetCore.Mvc;
using AutomatedEmailNotification.Services.EmailService;
using AutomatedEmailNotification.Models;

namespace AutomatedEmailNotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("sendConfirmation")]
        public IActionResult SendConfirmation([FromBody] RegistrationRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest("Email is required");
            }

            _emailService.SendConfirmationEmail(request.Email);
            return Ok();
        }
    }
}


    public class RegistrationRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
