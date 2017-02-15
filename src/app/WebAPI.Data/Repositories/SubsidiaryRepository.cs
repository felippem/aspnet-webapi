using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebAPI.Core.Interfaces.Repository;
using WebAPI.Core.Model.Agregates;
using WebAPI.Data.DataContext;

namespace WebAPI.Data.Repositories
{
    public class SubsidiaryRepository : Repository<Subsidiary>, ISubsidiaryRepository
    {
        public SubsidiaryRepository(Context manager)
            : base(manager)
        {
        }

        public override Subsidiary Get(long id)
        {
            if (!_manager.TestConnection()) return null;

            return base._dbSet.Where(w => w.Id == id)
                .Include(i => i.PostalAddress)
                .FirstOrDefault();
        }

        public override IEnumerable<Subsidiary> List()
        {
            if (!_manager.TestConnection()) return null;

            return base._dbSet.Where(w => !w.Deleted)
                .Include(i => i.PostalAddress);
        }

        public IEnumerable<Subsidiary> List(long establishmentId)
        {
            if (!_manager.TestConnection()) return null;

            return base._dbSet.Where(w => w.EstablishmentId == establishmentId && !w.Deleted)
                .Include(i => i.PostalAddress);
        }
    }
}
