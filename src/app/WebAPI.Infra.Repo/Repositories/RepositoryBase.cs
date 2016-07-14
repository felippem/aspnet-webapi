using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebAPI.Domain.Interfaces;
using WebAPI.Infra.Repo.DataContext;

namespace WebAPI.Infra.Repo.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        #region Fields

        protected ContextManager _manager { get; private set; }

        #endregion

        public RepositoryBase(ContextManager manager)
        {
            _manager = manager;
        }

        #region Behaviors

        public TEntity Create(TEntity obj)
        {
            if (!_manager.TestDatabase()) return null;

            return _manager.Context.Set<TEntity>().Add(obj);
        }

        public void Delete(TEntity obj)
        {
            if (!_manager.TestDatabase()) return;

            _manager.Context.Set<TEntity>().Remove(obj);
        }

        public void Delete(long id)
        {
            if (!_manager.TestDatabase()) return;

            _manager.Context.Set<TEntity>().Remove(Get(id));
        }

        public TEntity Get(long id)
        {
            if (!_manager.TestDatabase()) return null;

            return _manager.Context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> List()
        {
            if (!_manager.TestDatabase()) return null;

            return _manager.Context.Set<TEntity>().ToList();
        }

        public TEntity Update(TEntity obj)
        {
            if (!_manager.TestDatabase()) return null;

            _manager.Context.Entry(obj).State = EntityState.Modified;
            
            return obj;
        }

        #endregion
    }
}
