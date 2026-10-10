using FloridaIguanaTracker.Application.Sightings;
using FloridaIguanaTracker.Infrastructure.Persistence;
using FloridaIguanaTracker.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<FloridaIguanaTrackerDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FloridaIguanaTracker")));

builder.Services.AddScoped<ISightingRepository, SightingRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Serve the generated Swagger as JSON endpoint
    app.UseSwagger();

    // Serve Swagger UI at /swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Florida Iguana Tracker API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
