using System.Collections.Generic;
using WebAPI.Core.Model.Agregates;

namespace WebAPI.Core.Interfaces.Repository
{
    public interface IEstablishmentRepository : IRepository<Establishment>
    {
        IEnumerable<Establishment> ListByTag(string tag);
    }
}
