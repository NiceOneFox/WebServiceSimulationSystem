namespace Bll.Domain.Models;

public record FinalResults
{
    public double AverageProbabilityOfMaintenance { get; init; }
    public double BandwidthOfSystem { get; init; }
    public double ProbabilityOfFailure { get; init; }
};
