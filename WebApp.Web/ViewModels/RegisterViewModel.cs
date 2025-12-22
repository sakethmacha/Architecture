using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; } = null!;

        [Required]
        public string Role { get; set; } = "Employee";
    }
}
