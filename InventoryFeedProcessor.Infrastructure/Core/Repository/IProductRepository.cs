using System.Collections.Generic;

namespace InventoryFeedProcessor.Infrastructure
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetTopUsedProducts(int count);
        Product GetProductById(int id);
    }
}
