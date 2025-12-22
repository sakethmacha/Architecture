
using WebApp.Domain.Events;

namespace WebApp.Domain.Common
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> DomainEvent = new();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => DomainEvent;

        protected void AddDomainEvent(IDomainEvent eventItem)
        {
            DomainEvent.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            DomainEvent.Clear();
        }
    }
}
