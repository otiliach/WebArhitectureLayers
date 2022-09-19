using DataAccess.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Context
{
    public class CarpoolContext : IdentityDbContext< ApplicationUser,  IdentityRole<int>, int>
    {
        public CarpoolContext(DbContextOptions<CarpoolContext> options) : base(options)
        {
        }

        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }*/

       // public DbSet<Product> Products { get; set; }
        
    }
}   
    
