using Microsoft.AspNetCore.Builder;
using TodoApi.Middleware;
public static class SampleMiddlewareExtensions
{
    public static IApplicationBuilder UseSampleMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyMiddleware>();
    }
}