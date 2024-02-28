namespace MovieGallery.Infrastructure.Authentication;

public class JwtOptions
{
    public string Audience { get; set; }
    public int Expiration { get; set; }
    public string Issuer { get; set; }
    public string Secret { get; set; }
}