using Api.enums;
using Bll.Domain.Entities;
using Bll.Domain.Factories;
using Bll.Domain.Interfaces;

namespace Bll.Domain.Services;

public class SimulationService : ISimulationService
{
    private readonly ISourceManager _sourceManager;
    private readonly IDeviceManager _deviceManager;
    private readonly IBufferManagerFactory _bufferManagerFactory;

    public SimulationService(ISourceManager sourceManager, IDeviceManager deviceManager, IBufferManagerFactory bufferManagerFactory)
    {
        _sourceManager = sourceManager;
        _deviceManager = deviceManager;
        _bufferManagerFactory = bufferManagerFactory;
    }

    public void StartSimulation(InputParameters parameters)
    {
        // TODO CHOSE NUMBER OF SOURCES, SIZE OF BUFFER, NUMBER OF DEVICES.

        // TODO ALGORITHM OF CHOOSING REQUEST FROM SOURCE AND PUT IT ON DEVICE
        var source = new Source();
        var device = new Device();

        var bufferManager = _bufferManagerFactory.CreateBufferManager(parameters.SimulationType);

        var request =_sourceManager.GetNewRequest(source);

        bufferManager.Add(request);

        var requestFromBuffer = bufferManager.Get();

        if (requestFromBuffer == null) return;

        _deviceManager.TakeRequest(requestFromBuffer, device);

        // TODO MAKE SOME KIND OF JSON ANSWER.
    }
}