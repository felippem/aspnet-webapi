using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Infra.Data.DataContext;

namespace WebAPI.Infra.Data.Repositories
{
    public class PostalAddressRepository : Repository<PostalAddress>, IPostalAddressRepository
    {
        public PostalAddressRepository(Context manager)
            : base(manager)
        {
        }
    }
}
