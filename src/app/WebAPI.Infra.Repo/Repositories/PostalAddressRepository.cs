using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;
using WebAPI.Infra.Repo.DataContext;

namespace WebAPI.Infra.Repo.Repositories
{
    public class PostalAddressRepository : RepositoryBase<PostalAddress>, IPostalAddressRepository
    {
        public PostalAddressRepository(ContextManager manager)
            : base(manager)
        {
        }
    }
}
