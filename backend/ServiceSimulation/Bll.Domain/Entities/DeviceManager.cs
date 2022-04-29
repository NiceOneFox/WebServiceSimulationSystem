using Bll.Domain.Interfaces;
using Bll.Domain.Models;

namespace Bll.Domain.Entities;

public class DeviceManager : IDeviceManager
{
    private readonly ITimeProvider _time;

    private readonly IResults _resultChannel;

    private static readonly Random _random = new();

    public DeviceManager(ITimeProvider time, IResults resultChannel)
    {
        _time = time;
        _resultChannel = resultChannel;
    }

    public void TakeRequest(Request request, Device device)
    {
        if (device.IsWorking)
        {
            return;
        }
        device.Request = request;
        device.IsWorking = true;

        device.TimeOfDeviceWillBeFree = _time.Now + (-1.0 / device.Lambda) * Math.Log(_random.NextDouble());
    }

    public bool FreeDevice(Device device)
    {
        _ = device ?? throw new ArgumentNullException(nameof(device));
        device.Request.EndTime = _time.Now;

        _time.Now = device.Request.EndTime;

        _resultChannel.Processed.Add(device.Request);


        device.Request = null;
        device.IsWorking = false;

        return true;
    }
}