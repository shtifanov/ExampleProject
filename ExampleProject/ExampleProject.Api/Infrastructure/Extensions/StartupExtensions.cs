using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ExampleProject.Api.Infrastructure.Extensions
{
    internal static class StartupExtensions
    {
        public static void AddExceptionHandler(this IApplicationBuilder appBuilder)
        {
            appBuilder.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("An unexpected error occured, we are doing our best to correct it. Please try again later.");
            });
        }

    }
}