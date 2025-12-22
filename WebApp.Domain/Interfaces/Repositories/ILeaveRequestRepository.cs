
using WebApp.Domain.Aggregate;
namespace WebApp.Domain.Interfaces.Repositories
{
    public interface ILeaveRequestRepository
    {
        LeaveRequest GetById(int id);
        IEnumerable<LeaveRequest> GetPending();
        //IEnumerable<LeaveHistoryDto> GetHistory();
        void Save(LeaveRequest request);
    }
}
