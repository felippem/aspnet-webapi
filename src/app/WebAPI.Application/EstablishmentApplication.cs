using AutoMapper;
using System;
using System.Collections.Generic;
using WebAPI.Application.Interfaces;
using WebAPI.Application.ViewModels;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Infra.Repo.DataContext.UnitOfWork;

namespace WebAPI.Application
{
    public class EstablishmentApplication : ApplicationBase, IEstablishmentApplication
    {
        #region Fields

        private IEstablishmentService _establishmentService;
        private IPostalAddressService _postalAddressService;

        #endregion

        public EstablishmentApplication(IEstablishmentService establishmentService,
            IPostalAddressService postalAddressService,
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _establishmentService = establishmentService;
            _postalAddressService = postalAddressService;
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
                    establishment.PostalAddress = _postalAddressService.Save(establishment.PostalAddress);
                
                establishment = _establishmentService.Save(establishment);

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
            return Mapper.Map<Establishment, EstablishmentViewModel>(_establishmentService.Get(id));
        }

        public IEnumerable<EstablishmentViewModel> List()
        {
            return Mapper.Map<IEnumerable<Establishment>, IEnumerable<EstablishmentViewModel>>
                (_establishmentService.List());
        }

        public IEnumerable<EstablishmentViewModel> ListByTag(string tag)
        {
            return Mapper.Map<IEnumerable<Establishment>, IEnumerable<EstablishmentViewModel>>
                (_establishmentService.ListByTag(tag));
        }

        public bool Remove(long id)
        {
            try
            {
                Begin();

                _establishmentService.Remove(id);

                Commit();
            }
            catch
            {
                Rollback();
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            _establishmentService.Dispose();
            _postalAddressService.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
