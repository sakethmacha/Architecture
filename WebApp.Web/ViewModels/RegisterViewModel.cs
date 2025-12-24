using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Role is required")]
        public string? Role { get; set; } 

        public int LeaveBalance { get; set; } = 30;
    }
}
