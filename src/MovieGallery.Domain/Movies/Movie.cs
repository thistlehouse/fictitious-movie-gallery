using MovieGallery.Domain.Movies.Enums;

namespace MovieGallery.Domain.Domain.Movies;

public sealed class Movie
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Classification { get; private set; }
    public List<string> Cast { get; private set; } = [];
    public int Duration { get; private set; }
    public Uri ImageUrl { get; private set; }
    public string Synopsis { get; private set; }
    public MovieCategory Category { get; private set; }
    public decimal Rating { get; private set; }

    public Movie(
        Guid id,
        string name,
        string classification,
        List<string> cast,
        int duration,
        Uri imageUrl,
        string synopsis,
        MovieCategory category,
        decimal rating)
    {
        Id = id;
        Name = name;
        Classification = classification;
        Cast = cast;
        Duration = duration;
        ImageUrl = imageUrl;
        Synopsis = synopsis;
        Category = category;
        Rating = rating;
    }

    public static Movie Create(
        string name,
        string classification,
        List<string> cast,
        int duration,
        Uri imageUrl,
        string synopsis,
        MovieCategory category,
        decimal rating)
    {
        return new(
            Guid.NewGuid(),
            name,
            classification,
            cast,
            duration,
            imageUrl,
            synopsis,
            category,
            rating);
    }

#pragma warning disable CS8618
    public Movie()
    {
    }
#pragma warning restore CS8618
}