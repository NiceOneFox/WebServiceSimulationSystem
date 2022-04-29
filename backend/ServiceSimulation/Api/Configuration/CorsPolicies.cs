using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Api.Configuration;

public static class CorsPolicies
{
    public static readonly (string Name, Action<CorsPolicyBuilder> ConfigurePolicy) AllowRemoteFrontendWithCredentials =
    (
        "AllowRemoteFrontendWithCredentials",
        builder =>
        {
            var host = Environment.GetEnvironmentVariable("REMOTE_FRONTEND_HOST");
            var port = Environment.GetEnvironmentVariable("REMOTE_FRONTEND_PORT");
            var scheme = Environment.GetEnvironmentVariable("REMOTE_FRONTEND_SCHEME");
            var origin = $"{scheme}://{host}:{port}";
            builder
                .WithOrigins(origin)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        }
    );
}