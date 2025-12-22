
using WebApp.Application.DTOs;
using WebApp.Domain.Interfaces.Repositories;

namespace WebApp.Application.UseCases
{
    public class GetLeaveHistoryUseCase
    {
        private readonly ILeaveRequestRepository LeaveRepository;

        public GetLeaveHistoryUseCase(ILeaveRequestRepository leaveRepository)
        {
            LeaveRepository = leaveRepository;
        }

        //public IEnumerable<LeaveHistoryDto> Execute()
        //{
        //    return LeaveRepository.GetHistory();
        //}
    }
}
