using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Audiobooks.Data.Common.Contracts;

namespace Audiobooks.Data.Common
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly DbContext _ctx;
        private readonly DbSet<TEntity> _dbSet;
        protected RepositoryBase(DbContext ctx)
        {
            _ctx = ctx;
            _dbSet = ctx.Set<TEntity>();
        }

        public TEntity GetById(TKey id)
        {
            return _dbSet.Find(id);
        }

        public IReadOnlyCollection<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IReadOnlyCollection<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _ctx.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _ctx.SaveChanges();
        }
    }
}
