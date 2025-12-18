using Microsoft.EntityFrameworkCore;
using strivolabs_Assessment.Data;

namespace strivolabs_Assessment.Middlewares
{
    public class ServiceTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public ServiceTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext db)
        {
            if (context.Request.Path.StartsWithSegments("/api/auth/login"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue("X-Service-Id", out var serviceId) ||
                !context.Request.Headers.TryGetValue("X-Token-Id", out var token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Missing authentication headers");
                return;
            }

            var service = await db.Services
                .FirstOrDefaultAsync(s => s.ServiceId == serviceId);

            if (service == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid service");
                return;
            }

            var validToken = await db.ServiceTokens.FirstOrDefaultAsync(t =>
                t.ServiceId == service.Id &&
                t.Token == token &&
                t.ExpiresAt > DateTime.UtcNow);

            if (validToken == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid or expired token");
                return;
            }

            context.Items["Service"] = service;

            await _next(context);
        }
    }
}
