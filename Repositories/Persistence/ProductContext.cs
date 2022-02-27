using InventoryFeedProcessor.Repositories.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryFeedProcessor.Repositories
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base()
        {

        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
