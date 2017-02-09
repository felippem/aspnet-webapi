using System;
using System.Collections.Generic;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Interfaces.Services
{
    public interface ISubsidiaryService : IDisposable
    {
        Subsidiary Get(long id);
        IEnumerable<Subsidiary> List();
        IEnumerable<Subsidiary> List(long establishmentId);
        void Remove(long id);
        Subsidiary Save(Subsidiary subsidiary);
    }
}
