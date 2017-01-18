using AutoMapper;
using WebAPI.Application.ViewModels;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        #region Properties

        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        #endregion

        #region Behaviors

        protected override void Configure()
        {
            Mapper.CreateMap<Establishment, EstablishmentViewModel>();
            Mapper.CreateMap<PostalAddress, PostalAddressViewModel>();
            Mapper.CreateMap<Subsidiary, SubsidiaryViewModel>();
        }

        #endregion
    }
}