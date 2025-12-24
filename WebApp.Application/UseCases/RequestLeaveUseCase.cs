using WebApp.Domain.Interfaces.Repositories;
using WebApp.Domain.ValueObjects;
using WebApp.Domain.Aggregate;
namespace WebApp.Application.UseCases
{

    public class RequestLeaveUseCase
    {
        private readonly IEmployeeRepository EmployeeRepository;
        private readonly ILeaveRequestRepository LeaveRepository;

        public RequestLeaveUseCase(
            IEmployeeRepository employeeRepo,
            ILeaveRequestRepository leaveRepo)
        {
            EmployeeRepository = employeeRepo;
            LeaveRepository = leaveRepo;
        }

        public void Execute(string email, DateTime from, DateTime to)
        {
            //  Identify employee by email
            var employee = EmployeeRepository.GetByEmail(email);

            var period = new LeavePeriod(from, to);

            // DOMAIN RULE
            employee.DeductLeave(period.TotalDays);

            var leaveRequest = new LeaveRequest(employee.Id, period);

            EmployeeRepository.Update(employee);
            LeaveRepository.Save(leaveRequest);
        }


    }
}
