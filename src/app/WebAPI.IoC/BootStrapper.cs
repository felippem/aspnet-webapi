using SimpleInjector;
using WebAPI.Application;
using WebAPI.Application.Interfaces;
using WebAPI.Core.Interfaces.Repository;
using WebAPI.Core.Interfaces.Services;
using WebAPI.Core.Services;
using WebAPI.Data.DataContext;
using WebAPI.Data.DataContext.UnitOfWork;
using WebAPI.Data.Repositories;

namespace WebAPI.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IEstablishmentAppService, EstablishmentAppService>(Lifestyle.Scoped);
            container.Register<ISubsidiaryAppService, SubsidiaryAppService>(Lifestyle.Scoped);
            container.Register<IPostalAddressAppService, PostalAddressAppService>(Lifestyle.Scoped);

            container.Register<IEstablishmentService, EstablishmentService>(Lifestyle.Scoped);
            container.Register<IPostalAddressService, PostalAddressService>(Lifestyle.Scoped);
            container.Register<ISubsidiaryService, SubsidiaryService>(Lifestyle.Scoped);

            container.Register<IEstablishmentRepository, EstablishmentRepository>(Lifestyle.Scoped);
            container.Register<IPostalAddressRepository, PostalAddressRepository>(Lifestyle.Scoped);
            container.Register<ISubsidiaryRepository, SubsidiaryRepository>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnityOfWork>(Lifestyle.Scoped);
            container.Register<Context>(Lifestyle.Scoped);
        }
    }
}
