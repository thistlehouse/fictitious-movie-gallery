using Microsoft.Extensions.Options;

using MovieGallery.Infrastructure.Authentication;

namespace MovieGallery.Api.OptionsSetup.Authentication;

public class JwtOptionsSetup(IConfiguration configuration)
    : IConfigureOptions<JwtOptions>
{
    private const string Section = "JwtToken";
    private readonly IConfiguration _configuration = configuration;

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(Section).Bind(options);
    }
}