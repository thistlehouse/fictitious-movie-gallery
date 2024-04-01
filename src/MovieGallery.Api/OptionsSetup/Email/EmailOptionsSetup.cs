using Microsoft.Extensions.Options;

using MovieGallery.Infrastructure.Services.Email;

namespace MovieGallery.Api.OptionsSetup.Email;

public class EmailOptionsSetup(IConfiguration configuration)
    : IConfigureOptions<EmailOptions>
{
    private const string Section = "EmailService";
    private readonly IConfiguration _configuration = configuration;


    public void Configure(EmailOptions options)
    {
        _configuration.GetSection(Section).Bind(options);
    }
}