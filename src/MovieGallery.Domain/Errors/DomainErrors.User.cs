using MovieGallery.Domain.Common;

namespace MovieGallery.Domain.Errors;

public static partial class DomainErrors
{
    public static class User
    {
        public static readonly Error EmailAlreadyRegistered = new(
            "User.EmailAlreadyRegistered",
            "The email provided is already registered");

        public static readonly Error InvalidCredentials = new(
            "User.InvalidCredentials",
            "The provided credential is invalid");
    }
}