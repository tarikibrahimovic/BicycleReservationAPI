using System.Net;
using System.Text.Json;

namespace BicycleReservation.API.Middleware
{
    public class GlobalExcetionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public GlobalExcetionHandlingMiddleware(ILogger<GlobalExcetionHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;


                var result = JsonSerializer.Serialize(new { error = ex.Message });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }
        }
    }
}
