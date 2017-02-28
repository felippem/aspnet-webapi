using SharedKernel.DomainEventsDispatcher.Interfaces;
using WebAPI.Core.Interfaces.Services;
using WebAPI.Core.Model.DomainEvents;

namespace WebAPI.Core.Services.EventHandlers
{
    public class SendNotificationEstablishmentRemoved : IHandle<EstablishmentRemovedEvent>
    {
        private readonly ISmsService _smsService;
        
        public SendNotificationEstablishmentRemoved(ISmsService smsService)
        {
            _smsService = smsService;
        }

        public void Handle(EstablishmentRemovedEvent concretEvent)
        {
            _smsService.Send(string.Format("O estabelecimento {0} foi removido.", concretEvent.Establishment.AlternateName));
        }
    }
}
