using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class DeviceManager : IDeviceManager
{
    private readonly ITimeProvider _time;
    public DeviceManager(ITimeProvider time)
    {
        _time = time;
    }

    public void TakeRequest(Request request, Device device)
    {
        if (device.IsWorking)
        {
            return;
        }
        device.Request = request;

        //TODO COUNT TIME OF WORKING ON THAT REQUEST
    }

    public bool IsFree(Device device)
    {
        if (device.Request?.EndTime <= _time.Now)
        {
            device.Request = null;
            device.IsWorking = false;
            // TODO COUNT THAT REQUEST WHICH IS END WORKING.
        }
        return true;
    }
}