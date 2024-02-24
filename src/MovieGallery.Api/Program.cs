using MovieGallery.Api.Endpoints;
using MovieGallery.Application;
using MovieGallery.Infrastructure;
using MovieGallery.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure();

    builder.Services.AddRouting(options => options.LowercaseUrls = true);
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
    var services = app.Services.CreateScope();

    var context = services.ServiceProvider
        .GetRequiredService<MovieGalleryDbContext>();

    context.Database.EnsureCreated();
    context.SeedMovie(30);

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