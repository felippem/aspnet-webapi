using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Infra.Data.DataContext;

namespace WebAPI.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields

        protected Context _manager { get; private set; }

        #endregion

        public Repository(Context manager)
        {
            _manager = manager;
        }

        #region Behaviors

        public TEntity Create(TEntity obj)
        {
            if (!_manager.TestConnection()) return null;

            return _manager.Set<TEntity>().Add(obj);
        }

        public void Delete(TEntity obj)
        {
            if (!_manager.TestConnection()) return;

            _manager.Set<TEntity>().Remove(obj);
        }

        public void Delete(long id)
        {
            if (!_manager.TestConnection()) return;

            _manager.Set<TEntity>().Remove(Get(id));
        }

        public TEntity Get(long id)
        {
            if (!_manager.TestConnection()) return null;

            return _manager.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> List()
        {
            if (!_manager.TestConnection()) return null;

            return _manager.Set<TEntity>().ToList();
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

        #endregion
    }
}
