
namespace InventoryFeedProcessor.Infrastructure
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        void Complete();
    }
}
