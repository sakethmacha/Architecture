using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Application.Exceptions;
using WebApp.Application.UseCases;
using WebApp.Web.ViewModels;
namespace WebApp.Web.Controllers
{

    public class LeaveController : Controller
    {
        private readonly RequestLeaveUseCase RequestLeaveUseCase;
        private readonly ApproveLeaveUseCase ApproveLeaveUseCase;
        private readonly GetPendingLeaveRequestsUseCase GetPendingRequestUseCase;
        private readonly RejectRequestLeaveUseCase RejectRequestLeaveUseCase;

        public LeaveController(
            RequestLeaveUseCase requestLeaveUseCase,
            ApproveLeaveUseCase approveLeaveUseCase, GetPendingLeaveRequestsUseCase getPendingRequestUseCase, RejectRequestLeaveUseCase rejectRequestLeaveUseCase)
        {
            RequestLeaveUseCase = requestLeaveUseCase;
            ApproveLeaveUseCase = approveLeaveUseCase;
            GetPendingRequestUseCase = getPendingRequestUseCase;
            RejectRequestLeaveUseCase = rejectRequestLeaveUseCase;
        }

        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.None, NoStore =true)]
        public IActionResult Request()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Request(RequestLeaveViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (RequestLeaveUseCase == null)
            {
                throw new NotFoundException("User not found");
            }

            var email = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(email))
                return Unauthorized();


            RequestLeaveUseCase.Execute(
                email,
                model.From,
                model.To
            );

            return RedirectToAction("RequestSuccess");
        }

        public IActionResult RequestSuccess()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Approve(int leaveRequestId)
        {
           
            ApproveLeaveUseCase.Execute(leaveRequestId);

            TempData["Message"] = "Leave request approved successfully.";
            return RedirectToAction("ApproveSuccess");
        }
        [HttpGet]
        public IActionResult ApproveSuccess()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RejectSuccess()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Reject(int leaveRequestId)
        {
            RejectRequestLeaveUseCase.Execute(leaveRequestId);

            TempData["Message"] = "Leave request rejected.";
            return RedirectToAction("RejectSuccess");
        }

        //public IActionResult History()
        //{
        //    var history = GetLeaveHistoryUseCase.Execute();
        //    return View(history);
        //}

        [Authorize(Roles = "Admin")]
        public IActionResult Pending()
        {
            var requests = GetPendingRequestUseCase.Execute();
            return View(requests);
        }
    }
}
