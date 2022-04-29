using Bll.Domain.Interfaces;
using Bll.Domain.Models;

namespace Bll.Domain.Entities;

public class ResultManager : IResultManager
{
    private readonly IResults _results;
    private readonly ITimeProvider _timeProvider;
    public ResultManager(IResults results, ITimeProvider timeProvider)
    {
        _results = results;
        _timeProvider = timeProvider;
    }

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

    public FinalResults CalculateResultsOfModeling()
    {
        _results.ModelingTime = _timeProvider.Now;
        return new FinalResults
        {
            AverageProbabilityOfMaintenance = AverageProbabilityOfMaintenance(_results.AmountOfServedRequest,
                _results.AmountOfGeneratedRequests),
            BandwidthOfSystem = BandwidthOfSystem(_results.AmountOfServedRequest, _results.ModelingTime),
            ProbabilityOfFailure = ProbabilityOfFailure(_results.Cancelled.Count,
                _results.AmountOfGeneratedRequests),
        };
    }
}