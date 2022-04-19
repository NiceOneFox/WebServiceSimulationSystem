namespace Bll.Domain.Entities;

public class Device
{
    public int DeviceId { get; set; }
    public bool IsWorking { get; set; }
    public Request? Request { get; set; }
}