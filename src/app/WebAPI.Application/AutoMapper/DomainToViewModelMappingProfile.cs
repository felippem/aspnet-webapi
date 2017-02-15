using AutoMapper;
using WebAPI.Application.ViewModels;
using WebAPI.Core.Model;
using WebAPI.Core.Model.Agregates;

namespace WebAPI.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }
        
        protected override void Configure()
        {
            Mapper.CreateMap<Establishment, EstablishmentViewModel>();
            Mapper.CreateMap<PostalAddress, PostalAddressViewModel>();
            Mapper.CreateMap<Subsidiary, SubsidiaryViewModel>();
        }
    }
}