using System.Collections.Generic;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Interfaces
{
    public interface ISubsidiaryRepository : IRepositoryBase<Subsidiary>
    {
        IEnumerable<Subsidiary> List(long establishmentId);
    }
}
