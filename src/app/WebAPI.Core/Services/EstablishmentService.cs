using System;
using System.Collections.Generic;
using WebAPI.Core.Interfaces.Repository;
using WebAPI.Core.Interfaces.Services;
using WebAPI.Core.Model.Agregates;

namespace WebAPI.Core.Services
{
    public class EstablishmentService : IEstablishmentService
    {
        private IEstablishmentRepository _establishmentRepository;

        public EstablishmentService(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public Establishment Save(Establishment establishment)
        {
            if (establishment.Id == 0)
                establishment = _establishmentRepository.Create(establishment);
            else
                establishment = _establishmentRepository.Update(establishment);

            return establishment;
        }

        public void Remove(long id)
        {
            var establishment = Get(id);

            if (establishment == null) return;

            establishment.Remove();

            _establishmentRepository.Update(establishment);
        }

        public Establishment Get(long id)
        {
            return _establishmentRepository.Get(id);
        }

        public IEnumerable<Establishment> List()
        {
            return _establishmentRepository.List();
        }

        public IEnumerable<Establishment> ListByTag(string tag)
        {
            return _establishmentRepository.ListByTag(tag);
        }

        public void Dispose()
        {
            _establishmentRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}