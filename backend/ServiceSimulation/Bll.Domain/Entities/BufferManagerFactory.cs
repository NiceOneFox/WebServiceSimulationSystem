using Api.enums;
using Bll.Domain.Factories;
using Bll.Domain.Interfaces;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace Bll.Domain.Entities;

public class BufferManagerFactory : IBufferManagerFactory
{
    private readonly IServiceProvider _serviceProvider;

    public BufferManagerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IBufferManager CreateBufferManager(SimulationType simulationType, int capacity)
    {
        return simulationType switch
        {
            0 => new StandardBufferManager(_serviceProvider.GetRequiredService<IResults>(),
                _serviceProvider.GetRequiredService<ITimeProvider>(), capacity),
            _ => throw new NotImplementedException()
        };
    }
}