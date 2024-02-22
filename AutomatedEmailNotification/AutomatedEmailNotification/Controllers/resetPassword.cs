using AutomatedEmailNotification.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            try
            {
                // Send password reset email
                await SendPasswordResetEmail(request.Email);
                return Ok("Password reset email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Error sending password reset email: {ex.Message}");
            }
        }

        private async Task SendPasswordResetEmail(string email)
        {
            string emailHost = _config.GetSection("EmailHost").Value;
            string emailUsername = _config.GetSection("EmailUsername").Value;
            string emailPassword = _config.GetSection("EmailPassword").Value;

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailUsername);
                mail.To.Add(email);
                mail.Subject = "Password Reset";
                mail.Body = "Your password has been successfully reset.";

                using (SmtpClient smtp = new SmtpClient(emailHost, 587))
                {
                    smtp.Credentials = new NetworkCredential(emailUsername, emailPassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }



}

public class ResetPasswordRequest
{
    public required string Email { get; set; }
}









