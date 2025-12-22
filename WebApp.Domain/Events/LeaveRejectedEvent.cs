

namespace WebApp.Domain.Events
{
    public class LeaveRejectedEvent : IDomainEvent
    {
        public int LeaveRequestId { get; }
        public int EmployeeId { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public LeaveRejectedEvent(int leaveRequestId, int employeeId)
        {
            LeaveRequestId = leaveRequestId;
            EmployeeId = employeeId;
        }
    }
}
