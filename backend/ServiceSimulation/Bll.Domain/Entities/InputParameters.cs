using Api.enums;

namespace Bll.Domain.Entities;

public class InputParameters
{
    public int NumberOfSources { get; set; } = 3;
    public int NumberOfDevices { get; set; } = 2;
    public int BufferSize { get; set; } = 2;
    public int AmountOfRequests { get; set; } = 40;
    public double ModelingTime { get; set; } = double.MaxValue;
    public SimulationType SimulationType { get; set; } = SimulationType.Standard;
    public double Lambda { get; set; } = 3;
}