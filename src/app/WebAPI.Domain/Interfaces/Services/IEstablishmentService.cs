using System;
using System.Collections.Generic;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Interfaces.Services
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
