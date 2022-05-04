using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities
{
    public class AlgorithmBuilder
    {
        private Algorithm _algorithm = new();

        public AlgorithmBuilder WithDeviceManager(IDeviceManager deviceManager)
        {
            _algorithm.deviceManager = deviceManager;
            return this;
        }

        public AlgorithmBuilder WithSourceManager(ISourceManager sourceManager)
        {
            _algorithm.sourceManager = sourceManager;
            return this;
        }

        public AlgorithmBuilder WithBufferManager(IBufferManager bufferManager)
        {
            _algorithm.bufferManager = bufferManager;
            return this;
        }

        public AlgorithmBuilder WithDeviceDirector(IDeviceDirector deviceDirector)
        {
            _algorithm.deviceDirector = deviceDirector;
            return this;
        }

        public Algorithm Build()
        {
            Validation();
            return _algorithm;
        }

        private void Validation()
        {
            _ = _algorithm.deviceManager ?? throw new ArgumentNullException("DeviceManager is not constructed in builder");
            _ = _algorithm.sourceManager ?? throw new ArgumentNullException("SourceManager is not constructed in builder");
            _ = _algorithm.bufferManager ?? throw new ArgumentNullException("BufferManager is not constructed in builder");
            _ = _algorithm.deviceDirector ?? throw new ArgumentNullException("DeviceDirector is not constructed in builder");
        }
    }
}