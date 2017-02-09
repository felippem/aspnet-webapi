using System.Collections.Generic;
using System.Linq;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Infra.Data.DataContext;

namespace WebAPI.Infra.Data.Repositories
{
    public class EstablishmentRepository : Repository<Establishment>, IEstablishmentRepository
    {
        public EstablishmentRepository(Context manager)
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
            if (!_manager.TestConnection()) return null;

            return ListAvailable(_manager.Set<Establishment>().Where(o => o.Tags.Contains(tag)));
        }

        private IEnumerable<Establishment> ListAvailable(IEnumerable<Establishment> establishments) 
        {
            if (establishments == null) return establishments;

            return establishments.Where(w => w.Available());
        }

        #endregion
    }
}
