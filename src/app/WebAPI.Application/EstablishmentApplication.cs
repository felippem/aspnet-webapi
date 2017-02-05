using AutoMapper;
using System;
using System.Collections.Generic;
using WebAPI.Application.Interfaces;
using WebAPI.Application.ViewModels;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Infra.Repo.DataContext.UnitOfWork;

namespace WebAPI.Application
{
    public class EstablishmentApplication : ApplicationBase, IEstablishmentApplication
    {
        #region Fields

        private IEstablishmentRepository _establishmentRepository;
        private IPostalAddressApplication _postalAddressApplication;

        #endregion

        public EstablishmentApplication(IEstablishmentRepository establishmentRepository,
            IPostalAddressApplication postalAddressApplication,
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _establishmentRepository = establishmentRepository;
            _postalAddressApplication = postalAddressApplication;
        }

        #region Behaviors

        public EstablishmentViewModel Save(EstablishmentViewModel establishmentViewModel)
        {
            Establishment establishment = null;

            try
            {
                Begin();

                establishment = Mapper.Map<EstablishmentViewModel, Establishment>(establishmentViewModel);

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

            return Mapper.Map<Establishment, EstablishmentViewModel>(establishment);
        }

        public EstablishmentViewModel Get(long id)
        {
            return Mapper.Map<Establishment, EstablishmentViewModel>(_establishmentRepository.Get(id));
        }

        public IEnumerable<EstablishmentViewModel> List()
        {
            return Mapper.Map<IEnumerable<Establishment>, IEnumerable<EstablishmentViewModel>>
                (_establishmentRepository.List());
        }

        public IEnumerable<EstablishmentViewModel> ListByTag(string tag)
        {
            return Mapper.Map<IEnumerable<Establishment>, IEnumerable<EstablishmentViewModel>>
                (_establishmentRepository.ListByTag(tag));
        }

        public bool Remove(long id)
        {
            try
            {
                var establishment = _establishmentRepository.Get(id);

                if (establishment != null)
                {
                    establishment.Deleted = true;
                    _establishmentRepository.Update(establishment);

                    Commit();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            _establishmentRepository.Dispose();
            _postalAddressApplication.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
