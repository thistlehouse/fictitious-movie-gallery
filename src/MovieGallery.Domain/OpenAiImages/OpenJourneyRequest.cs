namespace MovieGallery.Domain.OpenAiImages;

public class OpenJourneyRequest
{
    public string Version { get; set; }
    public OpenJourneyInput Input { get; set; }
}