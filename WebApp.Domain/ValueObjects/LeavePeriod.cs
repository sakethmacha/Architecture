

namespace WebApp.Domain.ValueObjects
{
    public record LeavePeriod
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        private LeavePeriod() { } // EF Core

        public LeavePeriod(DateTime from, DateTime to)
        {
            if (from > to)
                throw new ArgumentException("From date must be before To date");
            From = from;
            To = to;
        }

        public int TotalDays => (To - From).Days + 1;
    }

}
