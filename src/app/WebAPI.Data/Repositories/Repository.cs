using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebAPI.Core.Interfaces.Repository;
using WebAPI.Data.DataContext;

namespace WebAPI.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly Context _manager;

        public Repository(Context manager)
        {
            _manager = manager;
            _dbSet = _manager.Set<TEntity>();
        }

        public TEntity Create(TEntity obj)
        {
            if (!_manager.TestConnection()) return null;

            return _dbSet.Add(obj);
        }

        public void Delete(TEntity obj)
        {
            if (!_manager.TestConnection()) return;

            _dbSet.Remove(obj);
        }

        public void Delete(long id)
        {
            if (!_manager.TestConnection()) return;

            _dbSet.Remove(Get(id));
        }

        public virtual TEntity Get(long id)
        {
            if (!_manager.TestConnection()) return null;

            return _dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> List()
        {
            if (!_manager.TestConnection()) return null;

            return _dbSet.ToList();
        }

        public TEntity Update(TEntity obj)
        {
            if (!_manager.TestConnection()) return null;

            _manager.Entry<TEntity>(obj).State = EntityState.Modified;

            return obj;
        }

        public void Dispose()
        {
            _manager.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
