
// Namespace declarations
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.IO;
using MimeKit;

namespace AutomatedEmailNotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ResetPasswordController(IConfiguration config)
        {
            _config = config;
        }
        // POST api/resetpassword
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            try
            {
                // Validate request data
                if (string.IsNullOrEmpty(request.Email))
                {
                    return BadRequest("Email cannot be empty.");
                }

                if (string.IsNullOrEmpty(request.NewPassword) || string.IsNullOrEmpty(request.ConfirmPassword))
                {
                    return BadRequest("New password and confirm password cannot be empty.");
                }

                if (request.NewPassword != request.ConfirmPassword)
                {
                    return BadRequest("Passwords do not match.");
                }

                // Send password reset email
                await SendPasswordResetEmail(request.Email);
                return Ok("Password reset email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Error sending password reset email: {ex.Message}");
            }
        }
        // Method to send password reset email
        private async Task SendPasswordResetEmail(string email)
        {
            string emailHost = _config.GetSection("EmailHost").Value;
            string emailUsername = _config.GetSection("EmailUsername").Value;
            string emailPassword = _config.GetSection("EmailPassword").Value;

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailUsername);
                mail.To.Add(email);
                mail.Subject = "Password Reset Successful!";
                mail.Body = "Your password has been reset successfully.";
           
                using (SmtpClient smtp = new SmtpClient(emailHost, 587))
                {
                    smtp.Credentials = new NetworkCredential(emailUsername, emailPassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }
    // Model for reset password request data
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}









