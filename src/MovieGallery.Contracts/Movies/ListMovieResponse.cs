namespace MovieGallery.Contracts.Movies;

public record ListMovieResponse(
    string Id,
    string Name,
    string Classification,
    List<string> Cast,
    int Duration,
    string ImageUrl,
    string Synopsis,
    string Category,
    decimal Rating);