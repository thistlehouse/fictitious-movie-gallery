using System.Net.Http.Headers;
using System.Net.Http.Json;

using MovieGallery.Application.Common.Services.OpenJourney;
using MovieGallery.Domain.OpenAiImages;

using Newtonsoft.Json;

namespace MovieGallery.Infrastructure.Services.OpenJourney;

public class OpenAiImageService : IOpenAiImageService
{
    public async Task<OpenJourneyResponse> CreatePrediction()
    {
        using var client = new HttpClient()
        {
            BaseAddress = new Uri("https://api.replicate.com"),
        };

        client.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));

        client.DefaultRequestHeaders.Add(
            "Authorization",
            "Token r8_TFKJjeiyTy8ZT4jOusxlzpqSS32F0Oi0pzUXI");

        var imageData = new OpenJourneyRequest
        {
            Version = "9936c2001faa2194a261c01381f90e65261879985476014a0a37a334593a05eb",
            Input = new OpenJourneyInput
            {
                Prompt = "mdjrny-v4 style a highly detailed matte painting of a man on a hill watching a rocket launch in the distance by studio ghibli, makoto shinkai, by artgerm, by wlop, by greg rutkowski, volumetric lighting, octane render, 4 k resolution, trending on artstation, masterpiece",
                Width = 300,
                Height = 512,
                NumOutPuts = 1,
                GuidanceScale = 14,
                NumInferenceSteps = 50,
            },
        };

        var response = await client.PostAsJsonAsync("v1/predictions", imageData);

        Console.WriteLine(response);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content
                .ReadFromJsonAsync<OpenJourneyResponse>();
        }
        else
        {
            var message = await response.Content.ReadAsStringAsync();

            throw new Exception(message);
        }
    }

    public async Task<string> GetImage()
    {
        var prediction = await CreatePrediction();

        using var client = new HttpClient();

        client.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));

        client.DefaultRequestHeaders.Add(
            "Authorization",
            "Token r8_TFKJjeiyTy8ZT4jOusxlzpqSS32F0Oi0pzUXI");

        int limitRequests = 10;
        int executions = 0;

        while (true)
        {
            var response = await client.GetAsync(prediction.Urls.Get);

            try
            {
                var image = await response
                    .Content
                    .ReadFromJsonAsync<OpenJourneyResponse>()
                    ?? throw new Exception("response missing");

                if (image!.Output!.Count != 0)
                {
                    return image.Output.FirstOrDefault() ?? default;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            executions++;

            if (executions > limitRequests)
            {
                return "still nothing";
            }

            await Task.Delay(TimeSpan.FromSeconds(2));
        }
    }
}