using MovieGallery.Domain.OpenAiImages;

namespace MovieGallery.Application.Common.Services.OpenJourney;

public interface IOpenAiImageService
{
    Task<string> GetImage();
    Task<OpenJourneyResponse> CreatePrediction();
}