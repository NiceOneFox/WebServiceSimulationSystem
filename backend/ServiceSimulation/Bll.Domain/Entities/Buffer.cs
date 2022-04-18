using Bll.Domain.Factories;
using Bll.Domain.Services;

namespace Bll.Domain.Entities;

public class Buffer : IBuffer
{
    private readonly IBufferManager _bufferManager; // FACTORY DESIGN PATTERN?

    public Buffer(IBufferManagerFactory bufferManager)
    {
        _bufferManager = bufferManager.CreateBufferManager();
    }

    public void Push(Request request)
    {
        _bufferManager.Add(request);
    }

    public Request? Pop()
    {
        return _bufferManager.Get();
    }
}