using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Audiobooks.Data.Common.Contracts
{
    public interface IRepositoryBase<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        TEntity GetById(TKey id);
        IReadOnlyCollection<TEntity> GetAll();
        IReadOnlyCollection<TEntity> GetAll(Func<TEntity, bool> predicate);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
