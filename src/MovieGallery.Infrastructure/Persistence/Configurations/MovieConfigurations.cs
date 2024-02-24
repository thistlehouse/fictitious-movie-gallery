using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MovieGallery.Domain.Domain.Movies;

namespace MovieGallery.Infrastructure.Persistence.Configurations;

public class MovieConfigurations : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        ConfigureMoviesTable(builder);
    }

    private static void ConfigureMoviesTable(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
    }
}