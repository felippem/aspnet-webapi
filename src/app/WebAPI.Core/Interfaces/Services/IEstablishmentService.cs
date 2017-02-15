using System;
using System.Collections.Generic;
using WebAPI.Core.Model.Agregates;

namespace WebAPI.Core.Interfaces.Services
{
    public interface IEstablishmentService : IDisposable
    {
        Establishment Save(Establishment establishment);
        Establishment Get(long id);
        IEnumerable<Establishment> List();
        IEnumerable<Establishment> ListByTag(string tag);
        void Remove(long id);
    }
}
