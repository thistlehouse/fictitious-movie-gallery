using Bogus;

using Microsoft.EntityFrameworkCore;

using MovieGallery.Application.Common.Services.OpenJourney;
using MovieGallery.Domain.Domain.Movies;
using MovieGallery.Domain.Movies.Enums;

namespace MovieGallery.Infrastructure.Persistence;

public class MovieGalleryDbContext(
    DbContextOptions<MovieGalleryDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }

    public void SeedMovie(int count)
    {
        string[] classification =
        [
            "P",
            "P-13",
            "G",
            "R",
            "NC-17",
        ];

        var faker = new Faker<Movie>()
            .RuleFor(m => m.Id, f => Guid.NewGuid())
            .RuleFor(m => m.Name, f => f.Lorem.Sentence(3))
            .RuleFor(m => m.Classification, f => classification[f.Random.Number(0, classification.Length - 1)])
            .RuleFor(m => m.Category, f => f.PickRandom<MovieCategory>())
            .RuleFor(m => m.Synopsis, f => f.Lorem.Paragraph(2))
            .RuleFor(m => m.Duration, f => f.Random.Number(45, 210))
            .RuleFor(m => m.ImageUrl, f => new Uri("https://placehold.co/320x560/png"))
            .RuleFor(m => m.Rating, f => Math.Round(f.Random.Decimal(3, 5), 1));

        Movies.AddRange(faker.Generate(count));

        SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(MovieGalleryDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}