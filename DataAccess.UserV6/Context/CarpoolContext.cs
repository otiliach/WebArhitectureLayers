using DataAccess.DataBase.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Context
{
    public class CarpoolContext : DbContext
    {
        public CarpoolContext(DbContextOptions<CarpoolContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; } 
        
    }
}
