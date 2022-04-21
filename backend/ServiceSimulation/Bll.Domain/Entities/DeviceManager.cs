using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class DeviceManager : IDeviceManager
{
    private readonly ITimeProvider _time;

    private readonly IResults _resultChannel;

    private static readonly Random _random = new();

    public double Lambda { get; set; }
    public double TimeOfDeviceWillBeFree { get; set; }

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

        TimeOfDeviceWillBeFree = _time.Now +(-1.0 / Lambda) * Math.Log(_random.NextDouble());
        //TODO COUNT TIME OF WORKING ON THAT REQUEST
    }

    public bool FreeDevice(Device device)
    {
        if (TimeOfDeviceWillBeFree <= _time.Now)
        {
            device.Request.EndTime = _time.Now;

            device.Request = null;
            device.IsWorking = false;

            // TODO COUNT THAT REQUEST WHICH IS END WORKING.
        }
        return true;
    }
}