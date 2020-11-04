using Microsoft.EntityFrameworkCore;
using ProductProject.Model;


namespace ProductProject.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            

        }
        public DbSet<Product> product { get; set; }

        public DbSet<Category> category { get; set; }

        public DbSet<Picture> picture { get; set; }

    }
}