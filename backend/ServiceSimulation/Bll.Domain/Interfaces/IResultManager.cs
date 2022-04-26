using Bll.Domain.Entities;

namespace Bll.Domain.Interfaces;

public interface IResultManager
{
    /// <summary>
    /// P = N served / N total
    /// </summary>
    double AverageProbabilityOfMaintenance(int amountOfServedRequests, int totalAmountOfRequests);

    /// <summary>
    /// A = N served / T modeling
    /// </summary>
    double BandwidthOfSystem(int amountOfServedRequests, double modelingTime);

    /// <summary>
    /// P failire of request = N declined / N total
    /// </summary>
    double ProbabilityOfFailure(int amountOfDeclinedRequests, int totalAmountOfRequests);
    public FinalResults CalculateResultsOfModeling();
}