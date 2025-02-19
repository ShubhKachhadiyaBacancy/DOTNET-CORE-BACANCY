using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace DAY2.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task? Invoke(HttpContext httpContext)
        {
            try
            {
                Console.WriteLine("ERROR HANDLING MIDDLEWARE");
                return _next(httpContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR OCCURRED IN APPLICATION");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
