using Bll.Domain.Entities;

namespace Bll.Domain.Interfaces;

public interface IDeviceManager
{
    void TakeRequest(Request request, Device device);
    bool FreeDevice(Device device);
}