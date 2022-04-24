using Bll.Domain.Entities;

namespace Bll.Domain.Interfaces;

public interface IBufferManager
{
    void Add(Request request);
    Request Get();
    bool IsFree();
}