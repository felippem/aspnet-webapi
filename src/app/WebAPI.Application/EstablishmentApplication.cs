using System;
using System.Collections.Generic;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;

namespace WebAPI.Application
{
    public class EstablishmentApplication : ApplicationBase
    {
        #region Fields

        private IEstablishmentRepository _establishmentRepository;
        private PostalAddressApplication _postalAddressApplication;

        #endregion

        public EstablishmentApplication(IEstablishmentRepository establishmentRepository,
            PostalAddressApplication postalAddressApplication,
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _establishmentRepository = establishmentRepository;
            _postalAddressApplication = postalAddressApplication;
        }

        #region Behaviors

        public Establishment Save(Establishment establishment)
        {
            try
            {
                Begin();

                if (establishment.PostalAddress != null)
                    establishment.PostalAddress = _postalAddressApplication.Save(establishment.PostalAddress);

                if (establishment.EstablishmentId == 0)
                {
                    establishment.Created = DateTime.Now;
                    establishment = _establishmentRepository.Create(establishment);
                }
                else
                    establishment = _establishmentRepository.Update(establishment);

                Commit();
            }
            catch
            {
                Rollback();
                establishment = null;
            }

            return establishment;
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

        public bool Remove(long id)
        {
            try
            {
                Begin();

                var establishment = Get(id);
                establishment.Deleted = true;

                _establishmentRepository.Update(establishment);

                Commit();
            }
            catch
            {
                Rollback();
                return false;
            }

            return true;
        }

        #endregion
    }
}
