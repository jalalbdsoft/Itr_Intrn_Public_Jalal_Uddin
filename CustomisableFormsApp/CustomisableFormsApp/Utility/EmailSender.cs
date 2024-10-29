using Microsoft.AspNetCore.Identity.UI.Services;

namespace CustomisableFormsApp.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //logic for sending email
            return Task.CompletedTask;
        }
    }
}
