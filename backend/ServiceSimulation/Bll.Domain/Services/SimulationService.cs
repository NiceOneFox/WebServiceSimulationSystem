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
    private readonly IResults _results;

    public SimulationService(ISourceManager sourceManager, IDeviceManager deviceManager, IBufferManagerFactory bufferManagerFactory)
    {
        _sourceManager = sourceManager;
        _deviceManager = deviceManager;
        _bufferManagerFactory = bufferManagerFactory;
    }

    public void StartSimulation(InputParameters parameters)
    {
        // TODO ALGORITHM OF CHOOSING REQUEST FROM SOURCE AND PUT IT ON DEVICE
        List<Source> sources = new List<Source>(parameters.NumberOfSources);
        List<Device> devices = new List<Device>(parameters.NumberOfDevices);
        var bufferManager = _bufferManagerFactory.CreateBufferManager(parameters.SimulationType);

        while (_results.AmountOfServedRequest != parameters.AmountOfRequests &&
               !bufferManager.IsFree() &&
               !IsAllDevicesFree(devices))
        {
            // TODO CHECK FOR NEXT SPECIAL EVENT
            // TODO FIND OUT HOW TO CHECK NEXT TIME FOR REQUEST AND DEVICE.
        }
       
        var request =_sourceManager.GetNewRequest(sources.FirstOrDefault());

        bufferManager.Add(request);

        var requestFromBuffer = bufferManager.Get();

        if (requestFromBuffer == null) return;

        _deviceManager.TakeRequest(requestFromBuffer, devices.FirstOrDefault());
    }

    public bool IsAllDevicesFree(List<Device> devices) =>
        devices.Any(d => d.IsWorking);

}