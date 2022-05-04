using Bll.Domain.enums;
using Bll.Domain.Factories;
using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities
{
    public class DeviceDirectorFactory : IDeviceDirectorFactory
    {
        public IDeviceDirector CreateDeviceDirector(DeviceDirectorType deviceDirectorType)
        {
            return deviceDirectorType switch
            {
                0 => new CircleDeviceDirector(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
