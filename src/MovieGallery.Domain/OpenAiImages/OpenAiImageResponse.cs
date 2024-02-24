namespace MovieGallery.Domain.OpenAiImages;

public class OpenJourneyResponse
{
    public string Id { get; set; }
    public string Model { get; set; }
    public string Version { get; set; }
    public OpenJourneyInput Input { get; set; }
    public string Logs { get; set; }
    public string Error { get; set; }
    public string Status { get; set; }
    public List<string>? Output { get; set; } = [];
    public DateTime CreatedAt { get; set; }
    public OpenJourneyUrls Urls { get; set; }
}

public class OpenJourneyUrls
{
    public string Cancel { get; set; }
    public string Get { get; set; }
}