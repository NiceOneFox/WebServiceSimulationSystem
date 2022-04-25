using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class ResultManager : IResultManager
{
    public double AverageProbabilityOfMaintenance(int amountOfServedRequests, int totalAmountOfRequests)
    {
        return amountOfServedRequests / (double)totalAmountOfRequests;
    }

    public double BandwidthOfSystem(int amountOfServedRequests, double modelingTime)
    {
        return amountOfServedRequests / modelingTime;
    }

    public double ProbabilityOfFailure(int amountOfDeclinedRequests, int totalAmountOfRequests)
    {
        return amountOfDeclinedRequests / (double)totalAmountOfRequests;
    }
}