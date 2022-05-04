using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities
{
    public class Algorithm
    {
        public ISourceManager sourceManager { get; set; }
        public IDeviceManager deviceManager { get; set; }
        public IBufferManager bufferManager { get; set; }
        public IDeviceDirector deviceDirector { get; set; }
    }
}
