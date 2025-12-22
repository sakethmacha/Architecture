using WebApp.Domain.Aggregate;
using WebApp.Domain.Interfaces.Repositories;
using WebApp.Infrastructure.Persistance;
namespace WebApp.Infrastructure.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext DbContext;

        public LeaveRequestRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public LeaveRequest GetById(int id)
        {
            var request = DbContext.LeaveRequests
                .SingleOrDefault(r => r.Id == id);

            if (request == null)
                throw new InvalidOperationException("Leave request not found");

            return request;
        }
        public IEnumerable<LeaveRequest> GetPending()
        {
            return DbContext.LeaveRequests
                .Where(l => l.Status == LeaveStatus.Requested)
                .ToList();
        }
        //public IEnumerable<LeaveHistoryDto> GetHistory()
        //{
        //    return DbContext.LeaveRequests
        //        .Where(l => l.Status != LeaveStatus.Requested)
        //        .Join(
        //            DbContext.Employees,
        //            l => l.EmployeeId,
        //            e => e.Id,
        //            (l, e) => new LeaveHistoryDto
        //            {
        //                LeaveRequestId = l.Id,
        //                EmployeeName = e.Name,
        //                EmployeeEmail = e.Email,
        //                From = l.Period.From,
        //                To = l.Period.To,
        //                Status = l.Status.ToString()
        //            })
        //        .OrderByDescending(x => x.From)
        //        .ToList();
        //}

        public void Save(LeaveRequest request)
        {
            if (request.Id == 0)
                DbContext.LeaveRequests.Add(request);
            else
                DbContext.LeaveRequests.Update(request);

            DbContext.SaveChanges();
        }
    }
}
