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
    public class SubsidiaryApplication : ApplicationBase, ISubsidiaryApplication
    {
        #region Fields

        private ISubsidiaryService _subsidiaryService;
        private IPostalAddressApplication _postalAddressApplication;
        private IEstablishmentService _establishmentService;

        #endregion

        public SubsidiaryApplication(ISubsidiaryService subsidiaryService,
            IPostalAddressApplication postalAddressApplication,
            IEstablishmentService establishmentService,
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _subsidiaryService = subsidiaryService;
            _postalAddressApplication = postalAddressApplication;
            _establishmentService = establishmentService;
        }

        #region Behaviors

        public SubsidiaryViewModel AddEstablishment(long id, EstablishmentViewModel establishmentViewModel)
        {
            Subsidiary subsidiary = null;
            
            try
            {
                subsidiary = _subsidiaryService.Get(id);

                if (subsidiary != null)
                {
                    subsidiary.Establishment = _establishmentService.Get(establishmentViewModel.EstablishmentKey);

                    subsidiary = _subsidiaryService.Save(subsidiary);
                    Commit();
                }
            }
            catch
            {
                establishmentViewModel = null;
            }

            return Mapper.Map<Subsidiary, SubsidiaryViewModel>(subsidiary);
        }

        public SubsidiaryViewModel Save(SubsidiaryViewModel subsidiaryViewModel)
        {
            Subsidiary subsidiary = null;

            try
            {
                Begin();

                subsidiary = Mapper.Map<SubsidiaryViewModel, Subsidiary>(subsidiaryViewModel);

                if (subsidiary.PostalAddress != null)
                    subsidiary.PostalAddress = _postalAddressApplication.Save(subsidiary.PostalAddress);

                subsidiary = _subsidiaryService.Save(subsidiary);

                Commit();
            }
            catch
            {
                Rollback();
                subsidiary = null;
            }

            return Mapper.Map<Subsidiary, SubsidiaryViewModel>(subsidiary);
        }

        public SubsidiaryViewModel Get(long id)
        {
            return Mapper.Map<Subsidiary, SubsidiaryViewModel>(_subsidiaryService.Get(id));
        }

        public IEnumerable<SubsidiaryViewModel> List()
        {
            return Mapper.Map<IEnumerable<Subsidiary>, IEnumerable<SubsidiaryViewModel>>
                (_subsidiaryService.List());
        }

        public IEnumerable<SubsidiaryViewModel> List(long establishmentId)
        {
            return Mapper.Map<IEnumerable<Subsidiary>, IEnumerable<SubsidiaryViewModel>>
                (_subsidiaryService.List(establishmentId));
        }

        public bool Remove(long id)
        {
            try
            {
                _subsidiaryService.Remove(id);
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
            _subsidiaryService.Dispose();
            _postalAddressApplication.Dispose();
            _establishmentService.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
