using Business.Services;
using Core.Contracts;
using Core.Repositories;
using DataAccess.UserRepository;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using DataAccess.Database.Models;
using Microsoft.AspNetCore.Identity;
using Business.Product;
using DataAccess.Products.Repository;
using WebApi.Authentication;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataAccess.Context.AppContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Carpool")));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase= false;
    options.Password.RequiredLength = 7;
    options.Password.RequiredUniqueChars = 1;
})
 .AddEntityFrameworkStores<DataAccess.Context.AppContext>()
 .AddDefaultTokenProviders();

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication",null);
builder.Services.AddAuthorization();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


//Add-Migration -Name InitialMigration -StartupProject CarpoolWebApi