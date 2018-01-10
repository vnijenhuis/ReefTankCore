using System.Threading.Tasks;

namespace ReefTankCore.Services.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendSignupEmailASync();
        Task SendSignupDeniedAsync();
        Task SendSignupConfirmedAsync();
    }
}
