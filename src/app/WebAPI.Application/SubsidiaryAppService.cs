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
    public class SubsidiaryAppService : ApplicationBase, ISubsidiaryAppService
    {
        private ISubsidiaryService _subsidiaryService;
        private IPostalAddressAppService _postalAddressApplication;
        private IEstablishmentService _establishmentService;

        public SubsidiaryAppService(ISubsidiaryService subsidiaryService,
            IPostalAddressAppService postalAddressApplication,
            IEstablishmentService establishmentService,
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _subsidiaryService = subsidiaryService;
            _postalAddressApplication = postalAddressApplication;
            _establishmentService = establishmentService;
        }
 
        public SubsidiaryViewModel Save(SubsidiaryViewModel subsidiaryViewModel)
        {
            Subsidiary subsidiary = null;

            try
            {   
                subsidiary = Mapper.Map<SubsidiaryViewModel, Subsidiary>(subsidiaryViewModel, _subsidiaryService.Get(subsidiaryViewModel.Key));

                if (subsidiary.IsValid)
                {
                    Begin();

                    if (subsidiary.PostalAddress != null)
                        subsidiary.AddAddress(_postalAddressApplication.Save(subsidiary.PostalAddress));

                    subsidiary = _subsidiaryService.Save(subsidiary);

                    Commit();
                }
            }
            catch(Exception ex)
            {
                Rollback();
                throw ex;
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
    }
}
