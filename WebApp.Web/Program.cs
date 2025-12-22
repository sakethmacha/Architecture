using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApp.Application.Interfaces;
using WebApp.Application.UseCases;
using WebApp.Domain.Common;
using WebApp.Domain.Events;
using WebApp.Domain.Interfaces.Repositories;
using WebApp.Infrastructure.Events;
using WebApp.Infrastructure.Persistance;
using WebApp.Infrastructure.Repositories;
using WebApp.Infrastructure.Security;
using WebApp.Web.Middlewares;
namespace WebApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
             builder.Configuration.GetConnectionString("Constr")));

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            builder.Services.AddScoped<RequestLeaveUseCase>();
            builder.Services.AddScoped<ApproveLeaveUseCase>();
            builder.Services.AddScoped<GetPendingLeaveRequestsUseCase>();
            builder.Services.AddScoped<RejectRequestLeaveUseCase>();
            builder.Services.AddScoped<RegisterUserUseCase>();
            builder.Services.AddScoped<LoginUserUseCase>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IEventHandler<LeaveRejectedEvent>, SendEmailOnLeaveRejected>();
            builder.Services.AddScoped<IEventHandler<LeaveApprovedEvent>, SendEmailOnLeaveApproved>();
            builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            builder.Services.AddAuthentication("Cookies")
            .AddCookie("Cookies", options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });

            // ---------------- AUTHORIZATION ----------------
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireRole("Admin"));
            });
            Log.Logger = new LoggerConfiguration()
                                .ReadFrom.Configuration(builder.Configuration)
                                .Enrich.FromLogContext()
                                .WriteTo.Console()
                                .WriteTo.File("logs/app-.log", rollingInterval: RollingInterval.Day)
                                .CreateLogger();

            builder.Host.UseSerilog();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
