using Microsoft.Extensions.DependencyInjection;
using WebApp.Domain.Common;
using WebApp.Domain.Events;

namespace WebApp.Infrastructure.Events
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider ServiceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public async Task DispatchAsync(IDomainEvent domainEvent)
        {
            var handlerType = typeof(IEventHandler<>)
                .MakeGenericType(domainEvent.GetType());

            var handlers = ServiceProvider.GetServices(handlerType);

            foreach (dynamic handler in handlers!)
            {
                await handler!.HandleAsync((dynamic)domainEvent);
            }
        }
    }
}
