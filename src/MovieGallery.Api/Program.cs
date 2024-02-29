using MovieGallery.Api;
using MovieGallery.Api.Endpoints;
using MovieGallery.Api.OptionsSetup.Authentication;
using MovieGallery.Application;
using MovieGallery.Infrastructure;
using MovieGallery.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure();

    builder.Services.ConfigureOptions<JwtOptionsSetup>();
    builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddCors(options =>
        options.AddDefaultPolicy(builder =>
            builder
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()));
}

var app = builder.Build();
{
    var context = app.Services
        .GetRequiredService<MovieGalleryDbContext>();

    context.SeedMovies(30);

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapApiEndpoints();
    app.UseHttpsRedirection();
    app.UseCors();
    app.Run();
}