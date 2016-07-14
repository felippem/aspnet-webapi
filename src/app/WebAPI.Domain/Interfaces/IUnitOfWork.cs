
namespace WebAPI.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
