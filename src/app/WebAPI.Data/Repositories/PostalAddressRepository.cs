using WebAPI.Core.Interfaces.Repository;
using WebAPI.Core.Model;
using WebAPI.Data.DataContext;

namespace WebAPI.Data.Repositories
{
    public class PostalAddressRepository : Repository<PostalAddress>, IPostalAddressRepository
    {
        public PostalAddressRepository(Context manager)
            : base(manager)
        {
        }
    }
}
