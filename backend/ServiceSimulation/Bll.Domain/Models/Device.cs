namespace Bll.Domain.Models;

public class Device
{
    public int DeviceId { get; set; }
    public bool IsWorking { get; set; }
    public Request? Request { get; set; }
    public double Lambda { get; set; } = 5;
    public double TimeOfDeviceWillBeFree { get; set; } = 0;
}