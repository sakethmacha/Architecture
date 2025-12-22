

using WebApp.Domain.Events;

namespace WebApp.Domain.Common
{
    public interface IEventHandler<in TEvent>
    where TEvent : IDomainEvent
    {
        Task HandleAsync(TEvent domainEvent);
    }

}
