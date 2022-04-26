using AutoMapper;

namespace Api.Configuration;

public static class MapperRegistration
{
    public static void AddMapper(this IServiceCollection services)
    {
        var mapper = new MapperConfiguration(cfg => cfg.AddApi());

        services.AddSingleton(mapper.CreateMapper());
    }
    public static IMapperConfigurationExpression AddApi(this IMapperConfigurationExpression expression)
    {
        return new ApiMapperConfigurator(expression).AddConfiguration();
    }
}