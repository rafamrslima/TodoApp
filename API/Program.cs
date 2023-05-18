using Microsoft.EntityFrameworkCore;
using MyApp.API.Infrastructure;
using MyApp.API.Core.Interfaces;
using MyApp.API.Application.Services;
using MyApp.API.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using MyApp.API.Application.Validators;
using MyApp.API.Application.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<DapperContext>();
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<MyAppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers
    (options => options.Filters.Add(typeof(ValidationFilter)))
.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserCreationValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(ErrorHandler));

app.UseHttpsRedirection();

app.UseCors(x => x
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

