using Microsoft.EntityFrameworkCore;
using ShotCaller.Application.Interfaces;
using ShotCaller.Infrastructure.Data;
using ShotCaller.Infrastructure.Repositories;
using ShotCaller.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IMatchService, MatchService>();

builder.Services.AddDbContext<ShotCallerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddCors(options =>
    options.AddPolicy("AllowFrontend", p =>
        p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.MapControllers();
app.Run();