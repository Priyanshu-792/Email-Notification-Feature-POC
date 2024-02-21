using AutomatedEmailNotification.Models;

namespace AutomatedEmailNotification.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
