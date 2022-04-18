using Bll.Domain.Services;

namespace Bll.Domain.Factories;

public interface IBufferManagerFactory
{
    IBufferManager CreateBufferManager();
}