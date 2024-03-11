using MediatR;

using MovieGallery.Domain.Common;

namespace MovieGallery.Application.Movies.Commands.AddRating;

public record AddRatingCommand(Guid Id, int Rating) : IRequest<Result>;