using Api.enums;

namespace Bll.Domain.Entities;

public class InputParameters
{
    public int NumberOfSources { get; set; }
    public int NumberOfDevices { get; set; }
    public int BufferSize { get; set; }
    public int AmountOfRequests { get; set; }
    public double ModelingTime { get; set; }
    public SimulationType SimulationType { get; set; }
}