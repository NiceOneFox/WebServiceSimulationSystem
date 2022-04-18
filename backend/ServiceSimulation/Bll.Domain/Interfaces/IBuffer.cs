using Bll.Domain.Entities;

namespace Bll.Domain.Interfaces;

public interface IBuffer
{
    void Push(Request request);
    Request? Pop();
}