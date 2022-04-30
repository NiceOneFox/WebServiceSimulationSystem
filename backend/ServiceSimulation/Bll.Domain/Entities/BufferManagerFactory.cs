using Api.enums;
using Bll.Domain.Factories;
using Bll.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bll.Domain.Entities;

public class BufferManagerFactory : IBufferManagerFactory
{
    private readonly IServiceProvider _serviceProvider;

    public BufferManagerFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IBufferManager CreateBufferManager(BufferType bufferType, int capacity)
    {
        return bufferType switch
        {
            BufferType.FIFO => new StandardBufferManager(_serviceProvider.GetRequiredService<IResults>(),
                _serviceProvider.GetRequiredService<ITimeProvider>(), capacity),
            BufferType.LIFO => new LIFOBufferManager(_serviceProvider.GetRequiredService<IResults>(),
                _serviceProvider.GetRequiredService<ITimeProvider>(), capacity),

            _ => throw new NotImplementedException()
        };
    }
}