using Coravel.Mailer.Mail;
using Coravel.Mailer.Mail.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using OikosPortal.Mailables;

namespace OikosPortal.Infra;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _config;
    private readonly IMailer _mailer;

    public EmailSender(IConfiguration config, IMailer mailer)
    {
        _config = config;
        _mailer = mailer;
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        await _mailer.SendAsync(new GenericMailable(email, _config.GetValue<string>("Coravel:Mail:Username"), subject, message));
    }
}
