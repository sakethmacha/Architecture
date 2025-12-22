using WebApp.Domain.Events;
using WebApp.Domain.Common;
using Microsoft.Extensions.Logging;

namespace WebApp.Infrastructure.Events
{
    public class SendEmailOnLeaveRejected
        : IEventHandler<LeaveRejectedEvent>
    {
        private readonly ILogger<SendEmailOnLeaveRejected> Logger;

        public SendEmailOnLeaveRejected(
            ILogger<SendEmailOnLeaveRejected> logger)
        {
            Logger = logger;
        }

        public Task HandleAsync(LeaveRejectedEvent domainEvent)
        {
            Logger.LogInformation(
                "Leave Rejected. LeaveId={LeaveId}, EmployeeId={EmployeeId}, Rejected At={OccurredOn}",
                domainEvent.LeaveRequestId,
                domainEvent.EmployeeId, domainEvent.OccurredOn);

            return Task.CompletedTask;
        }
    }
}
