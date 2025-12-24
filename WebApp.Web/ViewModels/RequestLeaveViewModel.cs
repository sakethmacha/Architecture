using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.ViewModels
{
    public class RequestLeaveViewModel
    {
        
        [Required(ErrorMessage = "Date is required")]
        public DateTime From { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime To { get; set; }

    }

}
