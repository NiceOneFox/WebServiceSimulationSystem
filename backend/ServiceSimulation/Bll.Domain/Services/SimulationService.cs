using Api.enums;
using Bll.Domain.Interfaces;

namespace Bll.Domain.Services;

public class SimulationService : ISimulationService
{
    private readonly ISource _source;
    private readonly IBuffer _buffer;
    private readonly IDevice _device;

    public SimulationService(ISource source, IBuffer buffer, IDevice device)
    {
        _source = source;
        _buffer = buffer;
        _device = device;
    }

    public void StartSimulation(SimulationType simulationType)
    {
        // TODO CHOSE NUMBER OF SOURCES, SIZE OF BUFFER, NUMBER OF DEVICES.

        // TODO ALGORITHM OF CHOOSING REQUEST FROM SOURCE AND PUT IT ON DEVICE
        var request =_source.GetNewRequest();

        _buffer.Push(request);

        var requestFromBuffer = _buffer.Pop();

        if (requestFromBuffer == null) return;

        _device.TakeRequest(requestFromBuffer);

        // TODO MAKE SOME KIND OF JSON ANSWER.
    }
}