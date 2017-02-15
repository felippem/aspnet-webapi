
namespace WebAPI.Data.DataContext.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
