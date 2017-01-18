using AutoMapper;
using WebAPI.Application.ViewModels;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        #region Properties

        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        #endregion

        #region Behaviors

        protected override void Configure()
        {
            Mapper.CreateMap<EstablishmentViewModel, Establishment>();
            Mapper.CreateMap<PostalAddressViewModel, PostalAddress>();
            Mapper.CreateMap<SubsidiaryViewModel, Subsidiary>();
        }

        #endregion
    }
}