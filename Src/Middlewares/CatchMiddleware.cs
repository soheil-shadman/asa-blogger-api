using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using AsaBloggerApi.Src.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AsaBloggerApi.Src.Middlewares
{
    public class CatchMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CatchMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public CatchMiddleware(RequestDelegate next, ILogger<CatchMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var json = JsonSerializer.Serialize(new ApiResponse
                {
                    Errors =  ex.Message,
                    Status=(int)HttpStatusCode.InternalServerError
                });
                await context.Response.WriteAsync(json);
            }
        }
    }
}