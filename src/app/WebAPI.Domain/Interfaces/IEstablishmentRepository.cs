using System.Collections.Generic;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Interfaces
{
    public interface IEstablishmentRepository : IRepositoryBase<Establishment>
    {
        IEnumerable<Establishment> ListByTag(string tag);
    }
}
