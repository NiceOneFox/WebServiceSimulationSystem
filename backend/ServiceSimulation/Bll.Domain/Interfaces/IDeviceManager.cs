using Bll.Domain.Models;

namespace Bll.Domain.Interfaces;

public interface IDeviceManager
{
    void TakeRequest(Request request, Device device);
    bool FreeDevice(Device device);
}