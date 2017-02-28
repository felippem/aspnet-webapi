using SharedKernel.DomainEventsDispatcher.Interfaces;
using System;
using WebAPI.Core.Model.Agregates;

namespace WebAPI.Core.Model.DomainEvents
{
    public class EstablishmentRemovedEvent : IDomainEvent
    {
        public DateTime DateTimeEventOccurred { get; private set; }
        public Establishment Establishment { get; set; }

        public EstablishmentRemovedEvent(Establishment establishment)
        {
            this.Establishment = establishment;
            this.DateTimeEventOccurred = DateTime.Now;
        }
    }
}
