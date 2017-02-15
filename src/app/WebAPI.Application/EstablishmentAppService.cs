using AutoMapper;
using System;
using System.Collections.Generic;
using WebAPI.Application.Interfaces;
using WebAPI.Application.ViewModels;
using WebAPI.Core.Interfaces.Services;
using WebAPI.Core.Model.Agregates;
using WebAPI.Data.DataContext.UnitOfWork;

namespace WebAPI.Application
{
    public class EstablishmentAppService : ApplicationBase, IEstablishmentAppService
    {
        private IEstablishmentService _establishmentService;
        private IPostalAddressAppService _postalAddressApplication;

        public EstablishmentAppService(IEstablishmentService establishmentService,
            IPostalAddressAppService postalAddressApplication,
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _establishmentService = establishmentService;
            _postalAddressApplication = postalAddressApplication;
        }

        public EstablishmentViewModel Save(EstablishmentViewModel establishmentViewModel)
        {
            Establishment establishment = null;

            try
            {
                establishment = Mapper.Map<EstablishmentViewModel, Establishment>(establishmentViewModel);

                if (establishment.IsValid)
                {
                    Begin();

                    if (establishment.PostalAddress != null)
                        establishment.AddAddress(_postalAddressApplication.Save(establishment.PostalAddress));

                    establishment = _establishmentService.Save(establishment);

                    Commit();
                }
            }
            catch(Exception ex)
            {
                Rollback();
                throw ex;
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
                _establishmentService.Remove(id);

                Commit();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            _establishmentService.Dispose();
            _postalAddressApplication.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
