using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlogAPI.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiKeyMiddleware> _logger;
        private readonly IConfiguration _configuration;

        public ApiKeyMiddleware(RequestDelegate next, ILogger<ApiKeyMiddleware> logger, IConfiguration configuration)
        {
            _next = next;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Skip API key validation for authenticated routes
            if (context.User.Identity?.IsAuthenticated == true)
            {
                await _next(context);
                return;
            }

            // Check API key for public endpoints (login/register)
            if (context.Request.Path.StartsWithSegments("/api/v1/login") ||
                context.Request.Path.StartsWithSegments("/api/v1/register"))
            {
                if (!context.Request.Headers.TryGetValue("X-API-Key", out var extractedApiKey))
                {
                    _logger.LogWarning("API Key missing");
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("API Key is missing");
                    return;
                }

                var apiKey = _configuration["ApiKey"];

                if (!apiKey.Equals(extractedApiKey))
                {
                    _logger.LogWarning("Invalid API Key");
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Invalid API Key");
                    return;
                }
            }

            await _next(context);
        }
    }
}