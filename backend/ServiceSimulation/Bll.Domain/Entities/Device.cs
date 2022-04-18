using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class Device : IDevice
{
    public int DeviceId { get; set; }
    public bool IsWorking { get; set; }
    public Request? Request { get; set; }
    private readonly ITimeProvider _time;
    public Device(int deviceId, bool isWorking, Request? request, ITimeProvider time)
    {
        DeviceId = deviceId;
        IsWorking = isWorking;
        Request = request;
        _time = time;
    }

    public void TakeRequest(Request request)
    {
        if (IsWorking)
        {
            return;
        }
        Request = request;

        //TODO COUNT TIME OF WORKING ON THAT REQUEST
    }

    public bool IsFree()
    {
        if (Request?.EndTime <= _time.Now)
        {
            Request = null;
            IsWorking = false;
            // TODO COUNT THAT REQUEST WHICH IS END WORKING.
        }
        return true;
    }
}