using Ninject.Modules;
using WebAPI.Domain.Interfaces;
using WebAPI.Infra.Repo.DataContext;
using WebAPI.Infra.Repo.Repositories;

namespace WebAPI.Infra.IoC
{
    public class IoCModule : NinjectModule
    {
        #region Behaviors

        public override void Load()
        {
            Bind(typeof(IUnitOfWork)).To(typeof(UnityOfWork));
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind(typeof(IEstablishmentRepository)).To(typeof(EstablishmentRepository));
            Bind(typeof(IPostalAddressRepository)).To(typeof(PostalAddressRepository));
            Bind<ContextManager>().ToSelf();
        }

        #endregion
    }
}
