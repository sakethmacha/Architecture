

namespace WebApp.Domain.ValueObjects
{
    public record LeavePeriod
    {
        public int Id {  get; set; }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        private LeavePeriod() { } // EF Core

        public LeavePeriod(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        public int TotalDays => (To - From).Days + 1;
    }

}
