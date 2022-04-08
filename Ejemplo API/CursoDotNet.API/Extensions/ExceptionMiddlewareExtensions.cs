using CursoDotNet.API.CustomExceptionMiddleware;
using Microsoft.AspNetCore.Builder;

namespace CursoDotNet.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
