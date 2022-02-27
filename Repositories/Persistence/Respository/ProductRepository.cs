
using InventoryFeedProcessor.Repositories.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace InventoryFeedProcessor.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {

        }       

        public ProductContext ProductContext
        {
            get { return Context as ProductContext; }
        }

        public IEnumerable<Product> GetTopUsedProducts(int count)
        {
            return ProductContext.Products.OrderByDescending(c => c.Categories).Take(count).ToList();
        }
    }
}