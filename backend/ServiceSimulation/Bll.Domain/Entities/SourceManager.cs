using Bll.Domain.Interfaces;
using Bll.Domain.Models;

namespace Bll.Domain.Entities;

public class SourceManager : ISourceManager
{
    private readonly ITimeProvider _time;

    private readonly IResults _results;

    private static Random _random = new();

    public SourceManager(ITimeProvider time, IResults results)
    {
        _time = time;
        _results = results;
    }

    public Request GetNewRequest(Source source)
    {
        var generatedRequest = new Request(source.SourceId, source.SerialNumber, source.TimeOfNextRequest, -1);
        
        source.TimeOfNextRequest += -(1.0 / source.Lambda) * Math.Log(_random.NextDouble());
        source.SerialNumber++;
        generatedRequest.SerialNumberOfSource = source.SerialNumber; // TODO REFACTOR? 

        _time.Now = source.TimeOfNextRequest;
        _results.AmountOfGeneratedRequests++;

        return generatedRequest;
    }
} // TODO Add Method Take NewRequest And GetTimeOfNextRequest ?