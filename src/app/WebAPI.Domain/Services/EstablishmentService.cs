using System;
using System.Collections.Generic;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Domain.Services
{
    public class EstablishmentService : IEstablishmentService
    {
        #region Fields

        private IEstablishmentRepository _establishmentRepository;

        #endregion

        public EstablishmentService(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        #region Behaviors

        public Establishment Save(Establishment establishment)
        {
            if (establishment.EstablishmentId == 0)
            {
                establishment.Created = DateTime.Now;
                establishment = _establishmentRepository.Create(establishment);
            }
            else
                establishment = _establishmentRepository.Update(establishment);

            return establishment;
        }

        public void Remove(long id)
        {
            var establishment = Get(id);
            establishment.Deleted = true;

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

        #endregion
    }
}