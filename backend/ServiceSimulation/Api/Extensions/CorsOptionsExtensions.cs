using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Api.Extensions;

public static class CorsOptionsExtensions
{
    public static void AddPolicy(this CorsOptions options, (string Name, Action<CorsPolicyBuilder> ConfigurePolicy) arg)
    {
        options.AddPolicy(arg.Name, arg.ConfigurePolicy);
    }

}