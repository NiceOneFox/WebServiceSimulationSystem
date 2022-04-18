using Bll.Domain.Entities;

namespace Bll.Domain.Interfaces;

public interface IDevice
{
    void TakeRequest(Request request);
    bool IsFree();
}