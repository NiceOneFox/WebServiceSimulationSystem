using Bll.Domain.Interfaces;
using Bll.Domain.Models;

namespace Bll.Domain.Entities;

public class DeviceManager : IDeviceManager
{
    private readonly ITimeProvider _time;

    private readonly IFlowProvider _flow;

    private readonly IResults _results;

    public DeviceManager(ITimeProvider time, IFlowProvider flowProvider, IResults results)
    {
        _time = time;
        _flow = flowProvider;
        _results = results;
    }

    public void TakeRequest(Request request, Device device)
    {
        if (device.IsWorking)
        {
            return;
        }
        device.Request = request;
        device.IsWorking = true;

        device.TimeOfDeviceWillBeFree = _flow.GetInterval(_time.Now, device.Lambda);
    }

    public bool FreeDevice(Device device)
    {
        _ = device.Request ?? throw new ArgumentNullException(nameof(device));
        device.Request.EndTime = _time.Now;

        _time.Now = device.Request.EndTime;

        _results.Processed.Add(device.Request);


        device.Request = null;
        device.IsWorking = false;

        return true;
    }
}