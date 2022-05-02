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

        public Algorithm Build()
        {
            return _algorithm;
        }
    }
}