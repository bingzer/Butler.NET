using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Logging;
using System.Threading.Tasks;

namespace Bingzer.Butler.Middlewares
{
    public class HttpLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public HttpLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("HTTP");
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
            _logger.LogInformation(context.Request.Method + " " + context.Response.StatusCode + " " + context.Request.Path);
        }
        
    }
}
