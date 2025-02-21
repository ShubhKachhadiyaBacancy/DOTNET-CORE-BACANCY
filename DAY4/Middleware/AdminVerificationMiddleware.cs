using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DAY4.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AdminVerificationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration configuration;

        public AdminVerificationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            this.configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/AdminVerification"))
            {
                string? password = httpContext.Request.Query["password"];
                if (password == null)
                {
                    await httpContext.Response.WriteAsync("PASSWORD IS NULL");
                    Console.WriteLine("PASSWORD IS NULL");
                    return;
                }
                else if (password != configuration.GetSection("Admin:Password").Value)
                {
                    //httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("PASSWORD NOT VERIFIED");
                    Console.WriteLine("PASSWORD NOT VERIFIED");
                    return;
                }
                else
                {
                    Console.WriteLine("PASSWORD VERIFIED");
                    await _next(httpContext);
                    Console.WriteLine(httpContext);
                }
            }
            else
            {
                await _next(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class VerificationMiddlewareExtensions
    {
        public static IApplicationBuilder UseVerificationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AdminVerificationMiddleware>();
        }
    }
}
