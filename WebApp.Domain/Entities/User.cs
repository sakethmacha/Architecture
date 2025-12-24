
using System.ComponentModel.DataAnnotations;

namespace WebApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Role is Required")]
        public string? Role { get; set; }
        [Required(ErrorMessage = "Role is Required")]
        public int LeaveBalance { get; set; }

        protected User() { } // EF

        public User(string name, string email, string passwordHash, string role, int leavebalance)
        {
            Name = name;
            Email = email;
            Password = passwordHash;
            Role = role;
            LeaveBalance = leavebalance;
        }
        public void DeductLeave(int days)
        {
            if (days > LeaveBalance)
                throw new InvalidOperationException("Insufficient leave balance");

            LeaveBalance -= days;
        }
    }
}
