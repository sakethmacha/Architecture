
using WebApp.Domain.Aggregate;
using WebApp.Domain.Interfaces.Repositories;

namespace WebApp.Application.UseCases
{
    public class GetPendingLeaveRequestsUseCase
    {
        private readonly ILeaveRequestRepository LeaveRepository;

        public GetPendingLeaveRequestsUseCase(ILeaveRequestRepository leaveRepository)
        {
            LeaveRepository = leaveRepository;
        }

        public IEnumerable<LeaveRequest> Execute()
        {
            return LeaveRepository.GetPending();
        }
    }

}
