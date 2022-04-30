using Bll.Domain.Interfaces;
using Bll.Domain.Models;

namespace Bll.Domain.Entities;

public class SourceManager : ISourceManager
{
    private readonly ITimeProvider _time;
    private readonly IFlowProvider _flow;
    private readonly IResults _results;

    public SourceManager(ITimeProvider time, IFlowProvider flowProvider, IResults results)
    {
        _time = time;
        _flow = flowProvider;
        _results = results;
    }

    public Request GetNewRequest(Source source) // THIS METHOD HAVE TO RETURN CURRENT Request and generate new? but cause problem with amount of generated and served requests
    {
        var generatedRequest = new Request(source.SourceId, source.SerialNumber, source.TimeOfNextRequest, null);

        source.TimeOfNextRequest = _flow.GetInterval(source.TimeOfNextRequest, source.Lambda);
        source.SerialNumber++;
        generatedRequest.SerialNumberOfSource = source.SerialNumber;

        _time.Now = source.TimeOfNextRequest;
        _results.AmountOfGeneratedRequests++;

        return generatedRequest;
    }
} // TODO Add Method Take NewRequest And GetTimeOfNextRequest ?