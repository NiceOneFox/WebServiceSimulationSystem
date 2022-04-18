using Bll.Domain.Entities;

namespace Bll.Domain.Services;

public interface IBuffer
{
    void Push(Request request);
    Request? Pop();
}