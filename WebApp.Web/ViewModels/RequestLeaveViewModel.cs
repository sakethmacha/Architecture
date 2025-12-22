using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.ViewModels
{
    public class RequestLeaveViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
    }
}
