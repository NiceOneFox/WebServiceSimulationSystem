using Api.enums;
using Bll.Domain.Factories;
using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class BufferManagerFactory : IBufferManagerFactory
{
    public IBufferManager CreateBufferManager(SimulationType simulationType)
    {
        return new StandardBufferManager();
    }
}