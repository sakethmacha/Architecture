

namespace WebApp.Application.DTOs
{
    public class LeaveHistoryDto
    {
        public int LeaveRequestId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeEmail { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string? Status { get; set; }
    }
}
