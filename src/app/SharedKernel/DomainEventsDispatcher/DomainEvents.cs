using SharedKernel.DomainEventsDispatcher.Interfaces;
using SimpleInjector;

namespace SharedKernel.DomainEventsDispatcher
{
    public static class DomainEvents
    {
        private static Container _container;
      
        public static void Initialize(Container container)
        {
            _container = container;
        }

        public static void Raise<T>(T concretEvent) where T : IDomainEvent
        {
            var handler = _container.GetInstance<IHandle<T>>();

            if (handler.Equals(null)) return;

            handler.Handle(concretEvent);
        }
    }
}
