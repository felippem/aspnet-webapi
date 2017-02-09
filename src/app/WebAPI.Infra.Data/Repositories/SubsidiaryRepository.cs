using System.Collections.Generic;
using System.Linq;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Infra.Data.DataContext;

namespace WebAPI.Infra.Data.Repositories
{
    public class SubsidiaryRepository : Repository<Subsidiary>, ISubsidiaryRepository
    {
        public SubsidiaryRepository(Context manager)
            : base(manager)
        {
        }

        #region Behaviors

        public override IEnumerable<Subsidiary> List()
        {
            return ListAvailable(base.List());
        }

        public IEnumerable<Subsidiary> List(long establishmentId)
        {
            if (!_manager.TestConnection()) return null;

            return _manager.Set<Subsidiary>().Where(o => o.Establishment.EstablishmentId == establishmentId);
        }

        private IEnumerable<Subsidiary> ListAvailable(IEnumerable<Subsidiary> subsidiaries)
        {
            if (subsidiaries == null) return subsidiaries;

            return subsidiaries.Where(w => w.Available());
        }

        #endregion
    }
}
