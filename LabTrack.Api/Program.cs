using LabTrack.Api.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
// sert a generer des descriptions des routes 

builder.Services.AddControllers();

const string FrontendCorsPolicy = "FrontendCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontendCorsPolicy, policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // desccription de l'api

    // preremplir la pase de donner si elle est vide
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        SeedData.Initialize(context);
    }
}

app.UseCors(FrontendCorsPolicy);

app.MapControllers();


app.UseHttpsRedirection();
// HTTP to HTTPS

// app.MapGet("/weatherforecast", () =>
// {

//     return "";
// })
// .WithName("GetWeatherForecast");

app.Run();
