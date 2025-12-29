using WebApp.Domain.Common;
using WebApp.Domain.Events;
using WebApp.Domain.ValueObjects;

namespace WebApp.Domain.Aggregate
{

    public enum LeaveStatus
    {
        Requested,
        Approved,
        Rejected
    }

    public class LeaveRequest : Entity 
    {
        public int Id { get; private set; }
        public int EmployeeId { get; private set; }
        public LeavePeriod? Period { get; private set; }
        public LeaveStatus Status { get; private set; }

        protected LeaveRequest() { } 

        public LeaveRequest(int employeeId, LeavePeriod period)
        {
            EmployeeId = employeeId;
            Period = period;
            Status = LeaveStatus.Requested;

            AddDomainEvent(new LeaveRequestedEvent(Id, EmployeeId));
        }

        public void Approve()
        {
            if (Status != LeaveStatus.Requested)
                throw new InvalidOperationException("Only requested leave can be approved");

            Status = LeaveStatus.Approved;

            AddDomainEvent(new LeaveRejectedEvent(Id, EmployeeId));
        }

        public void Reject()
        {
            if (Status != LeaveStatus.Requested)
                throw new InvalidOperationException("Only requested leave can be rejected");

            Status = LeaveStatus.Rejected;

            AddDomainEvent(new LeaveRejectedEvent(Id, EmployeeId));
        }
    }


}
