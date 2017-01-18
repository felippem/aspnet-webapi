using System.Collections.Generic;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Interfaces.Repository
{
    public interface IEstablishmentRepository : IRepository<Establishment>
    {
        IEnumerable<Establishment> ListByTag(string tag);
    }
}
