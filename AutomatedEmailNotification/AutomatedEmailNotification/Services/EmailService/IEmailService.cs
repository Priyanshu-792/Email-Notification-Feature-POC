

namespace AutomatedEmailNotification.Services.EmailService
{
    public interface IEmailService
    {
        void SendConfirmationEmail(string toEmail);
    }
}
