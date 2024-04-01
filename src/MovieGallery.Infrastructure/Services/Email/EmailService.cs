using MailKit.Net.Smtp;
using MailKit.Security;

using Microsoft.Extensions.Options;


using MimeKit;
using MimeKit.Text;

using MovieGallery.Application.Common.Services;
using MovieGallery.Domain.Users;
using MovieGallery.Infrastructure.Services.Email;


namespace MovieGallery.Infrastructure.Services;

public class EmailService(IOptions<EmailOptions> emailOptions) : IEmailService
{
    private const string Subject = "Confirm Registration";

    private readonly EmailOptions _emailOptions = emailOptions.Value;

    public void SendConfirmRegistrationMessage(User user)
    {
        var email = new MimeMessage();

        email.From.Add(MailboxAddress.Parse(_emailOptions.UserName));
        email.To.Add(MailboxAddress.Parse(_emailOptions.UserName));
        email.Subject = Subject;
        email.Body = new TextPart(TextFormat.Html)
        {
            Text = $"Hi {user.FirstName}, click <a href='http://localhost:5106/confirm'>here</a> to confirm your registration",
        };

        using var smtp = new SmtpClient();

        smtp.Connect(
            _emailOptions.Host,
            _emailOptions.Port,
            SecureSocketOptions.StartTls);

        smtp.Authenticate(_emailOptions.UserName, _emailOptions.Password);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}
