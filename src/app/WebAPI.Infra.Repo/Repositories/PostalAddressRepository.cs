using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Infra.Repo.DataContext;

namespace WebAPI.Infra.Repo.Repositories
{
    public class PostalAddressRepository : Repository<PostalAddress>, IPostalAddressRepository
    {
        public PostalAddressRepository(ContextManager manager)
            : base(manager)
        {
        }
    }
}
