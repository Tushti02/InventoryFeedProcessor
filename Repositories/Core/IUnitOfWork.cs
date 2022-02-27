
namespace InventoryFeedProcessor.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        void Complete();
    }
}
