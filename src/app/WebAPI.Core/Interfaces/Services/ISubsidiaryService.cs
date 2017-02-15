using System;
using System.Collections.Generic;
using WebAPI.Core.Model.Agregates;

namespace WebAPI.Core.Interfaces.Services
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
