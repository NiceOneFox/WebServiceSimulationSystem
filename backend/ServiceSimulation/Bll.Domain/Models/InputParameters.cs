using Api.enums;
using Bll.Domain.enums;

namespace Bll.Domain.Models;

public class InputParameters
{
    public int NumberOfSources { get; set; } = 3;
    public int NumberOfDevices { get; set; } = 2;
    public int BufferSize { get; set; } = 2;
    public int AmountOfRequests { get; set; } = 40;
    public double ModelingTime { get; set; } = double.MaxValue;
    public BufferType BufferType { get; set; } = BufferType.FIFO;
    public DeviceDirectorType deviceDirectorType { get; set; } = DeviceDirectorType.Circle;
    public double LambdaForRequests { get; set; } = 3;
    public double LambdaForDevice { get; set; } = 3;
}