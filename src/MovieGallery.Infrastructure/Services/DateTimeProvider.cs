using MovieGallery.Application.Common.Services;

namespace MovieGallery.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
