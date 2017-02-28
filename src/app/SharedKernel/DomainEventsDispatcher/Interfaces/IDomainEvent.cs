using System;

namespace SharedKernel.DomainEventsDispatcher.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DateTimeEventOccurred { get; }
    }
}
