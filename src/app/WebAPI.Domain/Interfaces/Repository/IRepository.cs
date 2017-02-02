using System;
using System.Collections.Generic;

namespace WebAPI.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Create(TEntity obj);
        void Delete(TEntity obj);
        void Delete(long id);
        TEntity Get(long id);
        IEnumerable<TEntity> List();
        TEntity Update(TEntity obj);
    }
}
