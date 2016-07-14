using WebAPI.Domain.Interfaces;

namespace WebAPI.Infra.Repo.DataContext
{
    public class UnityOfWork : IUnitOfWork
    {
        #region Fields

        private ContextManager _manager;

        #endregion

        public UnityOfWork(ContextManager manager)
        {
            _manager = manager;
        }

        #region Behaviors

        public void Begin()
        {
            _manager.Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _manager.Context.SaveChanges();

            if (_manager.Context.Database.CurrentTransaction == null) return;

            _manager.Context.Database.CurrentTransaction.Commit();
        }

        public void Rollback()
        {
            if (_manager.Context.Database.CurrentTransaction == null) return;

            _manager.Context.Database.CurrentTransaction.Rollback();
        }

        #endregion
    }
}
