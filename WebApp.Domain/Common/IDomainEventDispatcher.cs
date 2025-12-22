
using WebApp.Domain.Events;

namespace WebApp.Domain.Common
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(IDomainEvent domainEvent);
    }

}
