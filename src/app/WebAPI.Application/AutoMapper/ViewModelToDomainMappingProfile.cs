using AutoMapper;
using WebAPI.Application.ViewModels;
using WebAPI.Core.Model;
using WebAPI.Core.Model.Agregates;

namespace WebAPI.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EstablishmentViewModel, Establishment>()
                .ForMember(x => x.BrokenRules, opt => opt.Ignore())
                .ForMember(x => x.Created, opt => opt.Ignore());
            Mapper.CreateMap<PostalAddressViewModel, PostalAddress>()
                .ForMember(x => x.BrokenRules, opt => opt.Ignore())
                .ForMember(x => x.Created, opt => opt.Ignore());
            Mapper.CreateMap<SubsidiaryViewModel, Subsidiary>()
                .ForMember(x => x.BrokenRules, opt => opt.Ignore())
                .ForMember(x => x.Created, opt => opt.Ignore());
        }
    }
}