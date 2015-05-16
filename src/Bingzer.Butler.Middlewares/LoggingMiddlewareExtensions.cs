using Microsoft.AspNet.Builder;

namespace Bingzer.Butler.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HttpLoggingMiddleware>();
        }
    }
}
