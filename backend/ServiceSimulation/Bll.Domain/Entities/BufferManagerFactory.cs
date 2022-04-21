using Api.enums;
using Bll.Domain.Factories;
using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class BufferManagerFactory : IBufferManagerFactory
{
    private readonly IServiceProvider serviceProvider;

    public BufferManagerFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IBufferManager CreateBufferManager(SimulationType simulationType)
    {
        return simulationType switch
        {
            0 => (IBufferManager)serviceProvider.GetService(typeof(StandardBufferManager)),
            _ => throw new NotImplementedException()
        };
    }
}