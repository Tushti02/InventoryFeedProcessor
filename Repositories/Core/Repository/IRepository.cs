using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace InventoryFeedProcessor.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    }
}
