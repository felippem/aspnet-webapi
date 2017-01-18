using AutoMapper;

namespace WebAPI.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        #region Behaviors

        public static void RegisterMappings()
        {
            Mapper.Initialize(i =>
            {
                i.ReplaceMemberName("Id", "Key");
                i.ReplaceMemberName("Key", "Id");
                i.AddProfile<ViewModelToDomainMappingProfile>();
                i.AddProfile<DomainToViewModelMappingProfile>();
            });
        }

        #endregion
    }
}