
namespace WebAPI.Infra.Data.DataContext.UnitOfWork
{
    public class UnityOfWork : IUnitOfWork
    {
        #region Fields

        private Context _manager;

        #endregion

        public UnityOfWork(Context manager)
        {
            _manager = manager;
        }

        #region Behaviors

        public void Begin()
        {
            if (!_manager.TestConnection()) return;

            _manager.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (!_manager.TestConnection()) return;

            _manager.SaveChanges();

            if (_manager.Database.CurrentTransaction == null) return;

            _manager.Database.CurrentTransaction.Commit();
        }

        public void Rollback()
        {
            if (!_manager.TestConnection() || _manager.Database.CurrentTransaction == null) 
                return;

            _manager.Database.CurrentTransaction.Rollback();
        }

        #endregion
    }
}
