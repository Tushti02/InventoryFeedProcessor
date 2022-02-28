using Microsoft.EntityFrameworkCore;

namespace InventoryFeedProcessor.Infrastructure
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var IntValueConverter = new StringListToStringValueConverter();

            modelBuilder
                .Entity<Product>()
                .Property(e => e.Categories)
                .HasConversion(IntValueConverter);
            //modelBuilder.Entity<Product>().OwnsOne(x => x.Id);
        }

    }
}
