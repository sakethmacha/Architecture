using System.Xml.Linq;

namespace WebApp.Domain.Entities
{
    public class Employee
    {
        public int Id { get; }
        public string? Name { get; set; }

        public string? Email { get; set; }
       
        public int LeaveBalance { get; private set; }

        public Employee() { }   
        public Employee(string name, string email, int leaveBalance)
        {
            Name = name;
            Email = email;
            LeaveBalance = leaveBalance;
        }

        public void DeductLeave(int days)
        {
            if (days > LeaveBalance)
                throw new InvalidOperationException("Insufficient leave balance");

            LeaveBalance -= days;
        }
    }

}
