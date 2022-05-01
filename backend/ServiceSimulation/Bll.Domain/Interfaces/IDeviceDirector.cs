
using Bll.Domain.Models;

namespace Bll.Domain.Interfaces
{
    public interface IDeviceDirector
    {
        Device? ChooseDevice(IEnumerable<Device> devices, IDeviceManager deviceManager);
    }
}
