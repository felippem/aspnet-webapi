using AutoMapper;
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
        private IPostalAddressService _postalAddressService;
        private IEstablishmentService _establishmentService;

        #endregion

        public SubsidiaryApplication(ISubsidiaryService subsidiaryService,
            IPostalAddressService postalAddressService,
            IEstablishmentService establishmentService,
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _subsidiaryService = subsidiaryService;
            _postalAddressService = postalAddressService;
            _establishmentService = establishmentService;
        }

        #region Behaviors

        public SubsidiaryViewModel Save(SubsidiaryViewModel subsidiaryViewModel)
        {
            Subsidiary subsidiary = null;

            try
            {
                Begin();

                subsidiary = Mapper.Map<SubsidiaryViewModel, Subsidiary>(subsidiaryViewModel);

                if (subsidiary.PostalAddress != null)
                    subsidiary.PostalAddress = _postalAddressService.Save(subsidiary.PostalAddress);

                if (subsidiary.Establishment != null && subsidiary.Establishment.EstablishmentId > 0)
                    subsidiary.Establishment = _establishmentService.Get(subsidiary.Establishment.EstablishmentId);
                
                subsidiary = _subsidiaryService.Save(subsidiary);
                
                Commit();
            }
            catch
            {
                Rollback();
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
                Begin();

                _subsidiaryService.Remove(id);

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
