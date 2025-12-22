namespace WebApp.Domain.Events
{
    public sealed class LeaveApprovedEvent : IDomainEvent
    {
        public int LeaveRequestId { get; }
        public int EmployeeId { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public LeaveApprovedEvent(int leaveRequestId, int employeeId)
        {
            LeaveRequestId = leaveRequestId;
            EmployeeId = employeeId;
        }
    }
}
