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
    public class SubsidiaryApplication : ApplicationBase, ISubsidiaryApplication
    {
        #region Fields

        private ISubsidiaryRepository _subsidiaryRepository;
        private IPostalAddressApplication _postalAddressApplication;
        private IEstablishmentRepository _establishmentRepository;

        #endregion

        public SubsidiaryApplication(ISubsidiaryRepository subsidiaryRepository,
            IPostalAddressApplication postalAddressApplication,
            IEstablishmentRepository establishmentRepository,
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _subsidiaryRepository = subsidiaryRepository;
            _postalAddressApplication = postalAddressApplication;
            _establishmentRepository = establishmentRepository;
        }

        #region Behaviors

        public SubsidiaryViewModel AddEstablishment(long id, EstablishmentViewModel establishmentViewModel)
        {
            Subsidiary subsidiary = null;
            
            try
            {
                subsidiary = _subsidiaryRepository.Get(id);

                if (subsidiary != null)
                {
                    subsidiary.Establishment = _establishmentRepository.Get(establishmentViewModel.EstablishmentKey);

                    subsidiary = _subsidiaryRepository.Update(subsidiary);
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

            return Mapper.Map<Subsidiary, SubsidiaryViewModel>(subsidiary);
        }

        public SubsidiaryViewModel Get(long id)
        {
            return Mapper.Map<Subsidiary, SubsidiaryViewModel>(_subsidiaryRepository.Get(id));
        }

        public IEnumerable<SubsidiaryViewModel> List()
        {
            return Mapper.Map<IEnumerable<Subsidiary>, IEnumerable<SubsidiaryViewModel>>
                (_subsidiaryRepository.List());
        }

        public IEnumerable<SubsidiaryViewModel> List(long establishmentId)
        {
            return Mapper.Map<IEnumerable<Subsidiary>, IEnumerable<SubsidiaryViewModel>>
                (_subsidiaryRepository.List(establishmentId));
        }

        public bool Remove(long id)
        {
            try
            {
                _subsidiaryRepository.Delete(id);
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
            _subsidiaryRepository.Dispose();
            _postalAddressApplication.Dispose();
            _establishmentRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
