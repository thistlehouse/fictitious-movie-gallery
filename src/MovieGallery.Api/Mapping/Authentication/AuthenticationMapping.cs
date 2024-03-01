using Mapster;

using MovieGallery.Application.Authentication.Common;
using MovieGallery.Application.Authentication.Queries.Login;
using MovieGallery.Contracts.Authentication;
using MovieGallery.Domain.Movies.Users;

using LoginRequest = MovieGallery.Contracts.Authentication.LoginRequest;

namespace MovieGallery.Api.Mapping.Authentication;

public class AuthenticationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}