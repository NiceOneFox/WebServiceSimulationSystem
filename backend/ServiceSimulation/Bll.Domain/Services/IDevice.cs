using Bll.Domain.Entities;

namespace Bll.Domain.Services;

public interface IDevice
{
    void TakeRequest(Request request);
    bool IsFree();
}