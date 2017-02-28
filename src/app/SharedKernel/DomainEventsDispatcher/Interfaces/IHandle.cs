
namespace SharedKernel.DomainEventsDispatcher.Interfaces
{
    public interface IHandle<T> where T : IDomainEvent
    {
        void Handle(T concretEvent);
    }
}
