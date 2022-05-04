using Bll.Domain.enums;
using Bll.Domain.Interfaces;

namespace Bll.Domain.Factories
{
    public interface IDeviceDirectorFactory
    {
        public IDeviceDirector CreateDeviceDirector(DeviceDirectorType deviceDirectorType);
    }
}
