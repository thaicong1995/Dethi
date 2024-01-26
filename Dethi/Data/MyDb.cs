using Dethi.Model;
using Microsoft.EntityFrameworkCore;

namespace Dethi.Data
{
    public class MyDb : DbContext
    {
        public MyDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.Entity<Product>()
                 .Property(p => p.Price)
                 .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(p => p.TotalPrice)
                .HasColumnType("decimal(18,2)");
        }

    }
}
