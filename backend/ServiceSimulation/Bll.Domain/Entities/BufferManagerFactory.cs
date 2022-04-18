using Bll.Domain.Factories;
using Bll.Domain.Services;

namespace Bll.Domain.Entities;

public class BufferManagerFactory : IBufferManagerFactory
{
    public IBufferManager CreateBufferManager()
    {
        return new StandardBufferManager();
    }
}