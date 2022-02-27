using InventoryFeedProcessor.Repositories.Core.Domain;
using System.Collections.Generic;

namespace InventoryFeedProcessor.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetTopUsedProducts(int count);
    }
}
