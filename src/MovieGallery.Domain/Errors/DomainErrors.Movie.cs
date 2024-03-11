using MovieGallery.Domain.Common;

namespace MovieGallery.Domain.Errors;

public static partial class DomainErrors
{
    public static class Movie
    {
        public static readonly Func<Guid, Error> MovieNotFound = id => new(
            "Movie.NotFound",
            $"Movie with id: {id} was not found");

        public static readonly Func<string, Error> MovieOrMoviesNotFoundWithThatName = filter =>
            new(
                "MovieOrMovies.NotFound",
                "Movie or movies not found with given name");

        public static readonly Func<string, Error> MovieCategoryIsNotCorrectlySpecified = category =>
            new(
                "MovieCategory.DoesNotExistOrIsInAWrongFormat",
                $"Movie category {category} does not exists or is in a wrong format");
    }
}