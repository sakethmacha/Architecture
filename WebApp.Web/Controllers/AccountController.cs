using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Application.UseCases;
using WebApp.Domain.Entities;
using WebApp.Web.ViewModels;
namespace WebApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly RegisterUserUseCase RegisterUser;
        private readonly LoginUserUseCase LoginUser;

        public AccountController(
            RegisterUserUseCase registerUser,
            LoginUserUseCase loginUser)
        {
            RegisterUser = registerUser;
            LoginUser = loginUser;
        }

        // -------- REGISTER --------
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var success = await RegisterUser.Execute(
                model.Name,
                model.Email,
                model.Password,
                model.Role!,
                model.LeaveBalance=30
            );

            if (!success)
            {
                ModelState.AddModelError("", "User already exists");
                return View(model);
            }

            return RedirectToAction("Login");
        }

        // -------- LOGIN --------
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var claims = await LoginUser.Execute(
                model.Email,
                model.Password
            );

            if (claims == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(model);
            }

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("Cookies", principal);

            return RedirectToAction("LoginSuccess");
        }

        // -------- LOGOUT --------
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login");
        }

        // -------- RESULT PAGES --------
        [Authorize]
        public IActionResult LoginSuccess()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
