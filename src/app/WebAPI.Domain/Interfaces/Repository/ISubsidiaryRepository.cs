using System.Collections.Generic;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Interfaces.Repository
{
    public interface ISubsidiaryRepository : IRepository<Subsidiary>
    {
        IEnumerable<Subsidiary> List(long establishmentId);
    }
}
