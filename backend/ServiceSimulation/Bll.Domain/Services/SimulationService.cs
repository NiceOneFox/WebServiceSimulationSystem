using Api.enums;
using Bll.Domain.Entities;
using Bll.Domain.Interfaces;

namespace Bll.Domain.Services;

public class SimulationService : ISimulationService
{
    private readonly ISourceManager _sourceManager;
    private readonly IBuffer _buffer;
    private readonly IDeviceManager _deviceManager;

    public SimulationService(ISourceManager sourceManager, IBuffer buffer, IDeviceManager deviceManager)
    {
        _sourceManager = sourceManager;
        _buffer = buffer;
        _deviceManager = deviceManager;
    }

    public void StartSimulation(SimulationType simulationType)
    {
        // TODO CHOSE NUMBER OF SOURCES, SIZE OF BUFFER, NUMBER OF DEVICES.

        // TODO ALGORITHM OF CHOOSING REQUEST FROM SOURCE AND PUT IT ON DEVICE
        var source = new Source();
        var device = new Device();

        var request =_sourceManager.GetNewRequest(source);

        _buffer.Push(request);

        var requestFromBuffer = _buffer.Pop();

        if (requestFromBuffer == null) return;

        _deviceManager.TakeRequest(requestFromBuffer, device);

        // TODO MAKE SOME KIND OF JSON ANSWER.
    }
}