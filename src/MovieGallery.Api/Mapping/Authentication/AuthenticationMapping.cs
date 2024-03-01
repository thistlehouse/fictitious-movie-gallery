using Mapster;

using MovieGallery.Application.Authentication.Commands.Register;
using MovieGallery.Application.Authentication.Common;
using MovieGallery.Application.Authentication.Queries.Login;
using MovieGallery.Contracts.Authentication;

using LoginRequest = MovieGallery.Contracts.Authentication.LoginRequest;

namespace MovieGallery.Api.Mapping.Authentication;

public class AuthenticationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName)
            .Map(dest => dest.Email, src => src.User.Email);
    }
}