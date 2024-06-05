using Newtonsoft.Json;
using System.Net;

namespace BattleshipCodingTest.Utilities
{
    /// <summary>
    /// Middleware to handle exceptions during request processing and return a formatted JSON response with the error message.
    /// </summary>
    public class ExceptionHandlingMiddleware : Exception
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var jsonResponse = JsonConvert.SerializeObject(ex.Message);
                await httpContext.Response.WriteAsync(jsonResponse);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}