using Moq;
using SharedKernel.DomainEventsDispatcher;
using SharedKernel.DomainEventsDispatcher.Interfaces;
using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;
using WebAPI.Core.Model.Agregates;
using WebAPI.Core.Model.DomainEvents;
using Xunit;

namespace WebAPI.Tests
{
    [Trait("Ao excluir e restaurar um estabelecimento", "")]
    public class ExcluirUmEstabelecimento
    {
        public ExcluirUmEstabelecimento()
        {
            var smsHandler = new Mock<IHandle<EstablishmentRemovedEvent>>();
            smsHandler.Setup(x => x.Handle(It.IsAny<EstablishmentRemovedEvent>())).Verifiable();

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();
            DomainEvents.Initialize(container);

            container.RegisterSingleton(typeof(IHandle<EstablishmentRemovedEvent>), smsHandler.Object);
        }

        [Fact(DisplayName="ao excluir um estabelecimento, o mesmo deve ser indisponível")]
        public void ExcluindoUmEstabelecimento()
        {
            Establishment establishment = new Establishment
                (alternateName: "Bar Figueiras",
                legalName: "Comércio de bebidas figueiras",
                email: "whatever@email.com",
                telephone: "11999999999");

            establishment.Remove();

            Assert.False(establishment.Available());
        }

        [Fact(DisplayName="ao restaurar um estabelecimento, o mesmo deve ser disponível")]
        public void RestaurandoUmEstabelecimento()
        {
            Establishment establishment = new Establishment
                (alternateName: "Bar Figueiras",
                legalName: "Comércio de bebidas figueiras",
                email: "whatever@email.com",
                telephone: "11999999999");

            establishment.Restore();

            Assert.True(establishment.Available());
        }
    }
}
