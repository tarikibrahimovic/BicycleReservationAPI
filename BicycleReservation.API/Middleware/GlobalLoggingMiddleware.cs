using System.Diagnostics;

namespace BicycleReservation.API.Middleware
{
    public class GlobalLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalLoggingMiddleware> _logger;


        public GlobalLoggingMiddleware(RequestDelegate next, ILogger<GlobalLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var request = context.Request;
            var requestInfo = $"Request: {request.Method} {request.Path}";

            _logger.LogInformation(requestInfo);

            await _next(context);

            var response = context.Response;
            var responseInfo = $"Response: {response.StatusCode}";

            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Request duration: {elapsedMilliseconds}ms");
            _logger.LogInformation(responseInfo);
        }

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    var sw = new Stopwatch();
        //    sw.Start();

        //    await _next(context);

        //    sw.Stop();
        //    var elapsedMilliseconds = sw.ElapsedMilliseconds;
        //    _logger.LogInformation($"Vrijeme izvršavanja: {elapsedMilliseconds} ms");
        //}
    }
}
