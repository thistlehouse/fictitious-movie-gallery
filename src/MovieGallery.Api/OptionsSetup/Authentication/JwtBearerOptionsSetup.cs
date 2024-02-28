using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using MovieGallery.Infrastructure.Authentication;

namespace MovieGallery.Api.OptionsSetup.Authentication;

public class JwtBearerOptionsSetup(IOptions<JwtOptions> options)
    : IPostConfigureOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions = options.Value;

    public void PostConfigure(string? name, JwtBearerOptions options)
    {
        options.TokenValidationParameters.ValidateIssuer = true;
        options.TokenValidationParameters.ValidateAudience = true;
        options.TokenValidationParameters.ValidateLifetime = true;
        options.TokenValidationParameters.ValidateIssuerSigningKey = true;
        options.TokenValidationParameters.ValidIssuer = _jwtOptions.Issuer;
        options.TokenValidationParameters.ValidAudience = _jwtOptions.Audience;
        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtOptions.Secret));
    }
}