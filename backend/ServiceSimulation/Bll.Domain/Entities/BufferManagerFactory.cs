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

    public IBufferManager CreateBufferManager(SimulationType simulationType) // TODO PASS MORE PARAMETERS. SIZE BUFFER
    {
       // var a = ActivatorUtilities.CreateInstance<IBufferManager>(_serviceProvider, 
       //     new StandardBufferManager(_serviceProvider.GetRequiredService<IResults>(),
        //        _serviceProvider.GetRequiredService<ITimeProvider>(), 5));
        
        return simulationType switch
        {
            0 => new StandardBufferManager(_serviceProvider.GetRequiredService<IResults>(), _serviceProvider.GetRequiredService<ITimeProvider>(), 5),
            //0 => (IBufferManager)_serviceProvider.GetRequiredService(typeof(StandardBufferManager)),
            //0 => Activator.CreateInstance<IBufferManager>(nameof(StandardBufferManager), 5),// (IBufferManager)_serviceProvider.GetService(typeof(StandardBufferManager)),
            // 0 => ActivatorUtilities.CreateInstance<IBufferManager>(_serviceProvider,
            //    new StandardBufferManager(_serviceProvider.GetRequiredService<IResults>(), _serviceProvider.GetRequiredService<ITimeProvider>())),
            _ => throw new NotImplementedException()
        };
    }
}