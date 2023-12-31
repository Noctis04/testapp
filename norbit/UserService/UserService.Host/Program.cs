using Microsoft.EntityFrameworkCore;
using UserService.Host.Routes;
using UserService.Infrastructure.Contexts;
using UserService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("DefaultConnection")
    : Environment.GetEnvironmentVariable("CONNECTION_STRING");

builder.Services.AddDbContext<UserContext>(b =>b.UseNpgsql(connectionString));



builder.Services.AddBusinessLogic(builder.Configuration, connectionString!);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddUserRouter();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();
