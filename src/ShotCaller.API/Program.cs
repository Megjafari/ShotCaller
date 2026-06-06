using Microsoft.EntityFrameworkCore;
using ShotCaller.Application.Interfaces;
using ShotCaller.Application.Services;
using ShotCaller.Infrastructure.Data;
using ShotCaller.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Databas
builder.Services.AddDbContext<ShotCallerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IPredictionRepository, PredictionRepository>();

// Services
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IPredictionService, PredictionService>();
builder.Services.AddScoped<ILeaderboardService, LeaderboardService>();

// CORS
builder.Services.AddCors(options =>
    options.AddPolicy("AllowFrontend", p =>
        p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();   
}


app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.MapControllers();
app.Run();