
namespace InventoryFeedProcessor.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductContext _context;
        public UnitOfWork(ProductContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
        }
        public IProductRepository Products { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
