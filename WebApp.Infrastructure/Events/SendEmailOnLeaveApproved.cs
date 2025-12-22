using WebApp.Domain.Events;
using WebApp.Domain.Common;
using Microsoft.Extensions.Logging;

namespace WebApp.Infrastructure.Events
{
    public class SendEmailOnLeaveApproved
        : IEventHandler<LeaveApprovedEvent>
    {
        private readonly ILogger<SendEmailOnLeaveApproved> Logger;

        public SendEmailOnLeaveApproved(
            ILogger<SendEmailOnLeaveApproved> logger)
        {
            Logger = logger;
        }

        public Task HandleAsync(LeaveApprovedEvent domainEvent)
        {
            Logger.LogInformation(
                "Leave Approved. LeaveId={LeaveId}, EmployeeId={EmployeeId}, Approved At={OccurredOn}",
                domainEvent.LeaveRequestId,
                domainEvent.EmployeeId, domainEvent.OccurredOn);

            return Task.CompletedTask;
        }
    }
}
