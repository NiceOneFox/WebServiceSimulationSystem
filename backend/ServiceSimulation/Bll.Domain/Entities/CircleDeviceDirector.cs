using Bll.Domain.Interfaces;
using Bll.Domain.Models;

namespace Bll.Domain.Entities
{
    public class CircleDeviceDirector : IDeviceDirector
    {
        public Device? ChooseDevice(IEnumerable<Device> devices, IDeviceManager deviceManager)
        {
            foreach (var device in devices)
            {
                if (!device.IsWorking)
                {
                    return device;
                }
            }
            return null;
        }
    }
}
