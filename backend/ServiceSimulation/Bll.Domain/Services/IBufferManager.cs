using Bll.Domain.Entities;

namespace Bll.Domain.Services;

public interface IBufferManager
{
    void Add(Request request);
    Request? Get();
}