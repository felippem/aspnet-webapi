
namespace WebAPI.Infra.Repo.DataContext.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
