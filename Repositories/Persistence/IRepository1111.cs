using InventoryFeedProcessor.Models;
using System.Collections.Generic;
using System.Text;

namespace InventoryFeedProcessor.Repository
{
    public interface IRepository1111<T>
    {
        T Find(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
