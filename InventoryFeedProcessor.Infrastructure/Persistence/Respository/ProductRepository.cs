using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryFeedProcessor.Infrastructure
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
        public Product GetProductById(int id)
        {
            return ProductContext.Products.SingleOrDefault(a => a.Id == id);
        }
    }
}