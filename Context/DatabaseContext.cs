using Microsoft.EntityFrameworkCore;
using PracticeAPI.Models;

namespace PracticeAPI.Context
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
