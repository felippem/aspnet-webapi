using System.Collections.Generic;
using System.Linq;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;
using WebAPI.Infra.Repo.DataContext;

namespace WebAPI.Infra.Repo.Repositories
{
    public class EstablishmentRepository : RepositoryBase<Establishment>, IEstablishmentRepository
    {
        public EstablishmentRepository(ContextManager manager)
            : base(manager)
        {
        }

        #region Behaviors

        public override IEnumerable<Establishment> List()
        {
            return ListAvailable(base.List());
        }

        public IEnumerable<Establishment> ListByTag(string tag)
        {
            if (!_manager.TestDatabase()) return null;

            return ListAvailable(_manager.Context.Set<Establishment>().Where(o => o.Tags.Contains(tag)));
        }

        private IEnumerable<Establishment> ListAvailable(IEnumerable<Establishment> establishments) 
        {
            if (establishments == null) return establishments;

            return establishments.Where(w => w.Available());
        }

        #endregion
    }
}
