using WebApp.Domain.Common;
using WebApp.Domain.Interfaces.Repositories;
namespace WebApp.Application.UseCases
{
    public class ApproveLeaveUseCase
    {
        private readonly ILeaveRequestRepository LeaveRepository;
        private readonly IDomainEventDispatcher EventDispatcher;

        public ApproveLeaveUseCase(ILeaveRequestRepository leaveRepo, IDomainEventDispatcher eventDispatcher)
        {
            LeaveRepository = leaveRepo;
            EventDispatcher = eventDispatcher;
        }

        public void Execute(int leaveRequestId)
        {
            var request = LeaveRepository.GetById(leaveRequestId);

            request.Approve(); // DOMAIN RULE
            LeaveRepository.Save(request);
            foreach (var domainEvent in request.DomainEvents)
            {
                EventDispatcher.DispatchAsync(domainEvent);
            }

            request.ClearDomainEvents();
        }
    }
}
