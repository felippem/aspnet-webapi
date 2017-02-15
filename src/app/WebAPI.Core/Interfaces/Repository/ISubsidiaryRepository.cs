using System.Collections.Generic;
using WebAPI.Core.Model.Agregates;

namespace WebAPI.Core.Interfaces.Repository
{
    public interface ISubsidiaryRepository : IRepository<Subsidiary>
    {
        IEnumerable<Subsidiary> List(long establishmentId);
    }
}
