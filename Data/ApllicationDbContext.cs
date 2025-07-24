using Microsoft.EntityFrameworkCore;

namespace AspNetCoreForBeginners.Data
{
    public class ApllicationDbContext : DbContext
    {
        public ApllicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}
