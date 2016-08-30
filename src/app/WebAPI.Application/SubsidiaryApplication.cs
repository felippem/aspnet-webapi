using System;
using System.Collections.Generic;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;

namespace WebAPI.Application
{
    public class SubsidiaryApplication : ApplicationBase
    {
        #region Fields

        private ISubsidiaryRepository _subsidiaryRepository;
        private PostalAddressApplication _postalAddressApplication;
        private EstablishmentApplication _establishmentApplication;

        #endregion

        public SubsidiaryApplication(ISubsidiaryRepository subsidiaryRepository,
            PostalAddressApplication postalAddressApplication,
            EstablishmentApplication establishmentApplication,
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _subsidiaryRepository = subsidiaryRepository;
            _postalAddressApplication = postalAddressApplication;
            _establishmentApplication = establishmentApplication;
        }

        #region Behaviors

        public Subsidiary Save(Subsidiary subsidiary)
        {
            try
            {
                Begin();

                if (subsidiary.PostalAddress != null)
                    subsidiary.PostalAddress = _postalAddressApplication.Save(subsidiary.PostalAddress);

                if (subsidiary.Establishment != null && subsidiary.Establishment.EstablishmentId > 0)
                    subsidiary.Establishment = _establishmentApplication.Get(subsidiary.Establishment.EstablishmentId);

                if (subsidiary.SubsidiaryId == 0)
                {
                    subsidiary.Created = DateTime.Now;
                    subsidiary = _subsidiaryRepository.Create(subsidiary);
                }
                else
                    subsidiary = _subsidiaryRepository.Update(subsidiary);
                
                Commit();
            }
            catch
            {
                Rollback();
                subsidiary = null;
            }

            return subsidiary;
        }

        public Subsidiary Get(long id)
        {
            return _subsidiaryRepository.Get(id);
        }

        public IEnumerable<Subsidiary> List()
        {
            return _subsidiaryRepository.List();
        }

        public IEnumerable<Subsidiary> List(long establishmentId)
        {
            return _subsidiaryRepository.List(establishmentId);
        }

        public bool Remove(long id)
        {
            try
            {
                Begin();

                Subsidiary subsidiary = Get(id);
                subsidiary.Deleted = true;

                _subsidiaryRepository.Update(subsidiary);

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
