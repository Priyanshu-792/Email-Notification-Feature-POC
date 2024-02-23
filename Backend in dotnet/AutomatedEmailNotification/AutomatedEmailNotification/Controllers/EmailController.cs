

// Namespace declarations
using Microsoft.AspNetCore.Mvc;
using AutomatedEmailNotification.Services.EmailService;
using AutomatedEmailNotification.Models;

namespace AutomatedEmailNotification.Controllers
{
    // Controller for handling email-related requests
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        // POST api/email/sendConfirmation
        [HttpPost("sendConfirmation")]
        public IActionResult SendConfirmation([FromBody] RegistrationRequest request)
        {
            // Validate the request
            if (request == null || string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest("Email is required");
            }
            // Send confirmation email using the email service
            _emailService.SendConfirmationEmail(request.Email);
            return Ok();
        }
    }
}

// Model representing the registration request
public class RegistrationRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
}




