namespace MovieGallery.Domain.OpenAiImages;

public class OpenJourneyInput
{
    public int Width { get; set; }
    public int Height { get; set; }
    public string Prompt { get; set; }
    public int NumOutPuts { get; set; }
    public int GuidanceScale { get; set; }
    public int NumInferenceSteps { get; set; }
}