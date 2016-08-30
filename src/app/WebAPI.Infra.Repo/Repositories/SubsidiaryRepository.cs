using System.Collections.Generic;
using System.Linq;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;
using WebAPI.Infra.Repo.DataContext;

namespace WebAPI.Infra.Repo.Repositories
{
    public class SubsidiaryRepository : RepositoryBase<Subsidiary>, ISubsidiaryRepository
    {
        public SubsidiaryRepository(ContextManager manager)
            : base(manager)
        {
        }

        public override IEnumerable<Subsidiary> List()
        {
            return ListAvailable(base.List());
        }

        public IEnumerable<Subsidiary> List(long establishmentId)
        {
            if (!_manager.TestDatabase()) return null;

            return _manager.Context.Set<Subsidiary>().Where(o => o.Establishment.EstablishmentId == establishmentId);
        }

        private IEnumerable<Subsidiary> ListAvailable(IEnumerable<Subsidiary> subsidiaries)
        {
            if (subsidiaries == null) return subsidiaries;

            return subsidiaries.Where(w => w.Available());
        }
    }
}
