using MovieGallery.Domain.Movies.Enums;

namespace MovieGallery.Domain.Domain.Movies;

public sealed class Movie
{
    public Guid Id { get; private set; }
    public string Year { get; private set; }
    public string Name { get; private set; }
    public string Classification { get; private set; }
    public List<string> Cast { get; private set; } = [];
    public int Duration { get; private set; }
    public Uri ImageUrl { get; private set; }
    public string Synopsis { get; private set; }
    public MovieCategory Category { get; private set; }
    public decimal? Rating { get; private set; }
    public int NumberRatings { get; private set; }

    private Movie(
        Guid id,
        string year,
        string name,
        string classification,
        List<string> cast,
        int duration,
        Uri imageUrl,
        string synopsis,
        MovieCategory category)
    {
        Id = id;
        Year = year;
        Name = name;
        Classification = classification;
        Cast = cast;
        Duration = duration;
        ImageUrl = imageUrl;
        Synopsis = synopsis;
        Category = category;
    }

    public static Movie Create(
        string year,
        string name,
        string classification,
        List<string> cast,
        int duration,
        Uri imageUrl,
        string synopsis,
        MovieCategory category)
    {
        return new(
            Guid.NewGuid(),
            year,
            name,
            classification,
            cast,
            duration,
            imageUrl,
            synopsis,
            category);
    }

    public void AddNewRating(int rating)
    {
        Rating = ((Rating * NumberRatings) + rating) / ++NumberRatings;
    }

    public void RemoveRating(int rating)
    {
        Rating = ((Rating * NumberRatings) - rating) / --NumberRatings;
    }

#pragma warning disable CS8618
    public Movie()
    {
    }
#pragma warning restore CS8618
}