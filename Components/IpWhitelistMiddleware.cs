namespace DotNetWebAPI.Components
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using System.Linq;
    using System.Threading.Tasks;

    public class IpWhitelistMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public IpWhitelistMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var allowedIps = _configuration.GetSection("IpWhitelist:AllowedIPs").Get<string[]>();
            var remoteIp = context.Connection.RemoteIpAddress?.ToString();

            if (allowedIps != null && !allowedIps.Contains(remoteIp))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden: IP address not allowed.");
                return;
            }

            await _next(context);
        }
    }

}
