using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebAPI.Core.Interfaces.Repository;
using WebAPI.Core.Model.Agregates;
using WebAPI.Data.DataContext;

namespace WebAPI.Data.Repositories
{
    public class EstablishmentRepository : Repository<Establishment>, IEstablishmentRepository
    {
        public EstablishmentRepository(Context manager)
            : base(manager)
        {
        }

        public override Establishment Get(long id)
        {
            if (!_manager.TestConnection()) return null;

            return base._dbSet.Where(w => w.Id == id).Include(i => i.PostalAddress).FirstOrDefault();
        }

        public override IEnumerable<Establishment> List()
        {
            if (!_manager.TestConnection()) return null;

            return base._dbSet.Where(w => !w.Deleted).Include(i => i.PostalAddress);
        }

        public IEnumerable<Establishment> ListByTag(string tag)
        {
            if (!_manager.TestConnection()) return null;

            return base._dbSet.Where(o => o.Tags.Contains(tag)).Include(i => i.PostalAddress);
        }
    }
}
