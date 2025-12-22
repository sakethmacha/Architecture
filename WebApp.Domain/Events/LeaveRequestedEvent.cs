

namespace WebApp.Domain.Events
{
    public class LeaveRequestedEvent : IDomainEvent
    {
        public int LeaveRequestId { get; }
        public int EmployeeId { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public LeaveRequestedEvent(int leaveRequestId, int employeeId)
        {
            LeaveRequestId = leaveRequestId;
            EmployeeId = employeeId;
        }
    }
}
