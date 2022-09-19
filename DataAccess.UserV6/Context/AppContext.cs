using DataAccess.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Context
{
    public class AppContext : IdentityDbContext< ApplicationUser,  IdentityRole<int>, int>
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }*/

       public DbSet<Product> Products { get; set; }
        
    }
}   
    
