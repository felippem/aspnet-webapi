using SimpleInjector;
using WebAPI.Application;
using WebAPI.Application.Interfaces;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Infra.Repo.DataContext;
using WebAPI.Infra.Repo.DataContext.UnitOfWork;
using WebAPI.Infra.Repo.Repositories;

namespace WebAPI.Infra.IoC
{
    public static class BootStrapper
    {
        #region Behaviors

        public static void RegisterServices(Container container)
        {
            container.Register<IEstablishmentApplication, EstablishmentApplication>(Lifestyle.Scoped);
            container.Register<ISubsidiaryApplication, SubsidiaryApplication>(Lifestyle.Scoped);
            container.Register<IPostalAddressApplication, PostalAddressApplication>(Lifestyle.Scoped);

            container.Register<IEstablishmentRepository, EstablishmentRepository>(Lifestyle.Scoped);
            container.Register<IPostalAddressRepository, PostalAddressRepository>(Lifestyle.Scoped);
            container.Register<ISubsidiaryRepository, SubsidiaryRepository>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnityOfWork>(Lifestyle.Scoped);
            container.Register<Context>(Lifestyle.Scoped);
        }

        #endregion
    }
}
