
using WebApp.Application.Exceptions;
namespace WebApp.Web.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate Next;
        private readonly ILogger<GlobalExceptionMiddleware> Logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            Next = next;
            Logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context); // continue request pipeline
            }
            catch (NotFoundException ex)
            {
                Logger.LogWarning(ex, "Resource not found");
                context.Response.StatusCode = 404;
                //await context.Response.WriteAsync(ex.Message);
                context.Response.Redirect("/Error/404");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Unhandled exception occurred");
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/plain";
               
                //await context.Response.WriteAsync("Something went wrong.");
                 context.Response.Redirect("/Error");
            }
        }
    }

}
