namespace Api.Entities;

public record ApiResults
{
    public double ModelingTime { get; init; }
    public int AmountOfGeneratedRequests { get; init; }
    public int AmountOfServedRequest { get; init; }
    public double AverageProbabilityOfMaintenance { get; init; }
    public double BandwidthOfSystem { get; init; }
    public double ProbabilityOfFailure { get; init; }
}