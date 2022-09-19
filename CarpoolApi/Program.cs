using Business.Services;
using Core.Contracts;
using Core.Repositories;
using DataAccess.UserRepository;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using DataAccess.Database.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarpoolContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Carpool")));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRepository<ApplicationUser>, UserRepository>();

builder.Services.AddIdentity<ApplicationUser,IdentityRole<int>>()
 .AddEntityFrameworkStores<CarpoolContext>()
 .AddDefaultTokenProviders();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//Add-Migration -Name InitialMigration -StartupProject CarpoolWebApi