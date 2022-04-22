using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class SourceManager : ISourceManager
{
    private readonly ITimeProvider _time;

    private static Random _random = new();
    public SourceManager(ITimeProvider time)
    {
        _time = time;
    }

    public Request GetNewRequest(Source source)
    {
        source.TimeOfNextRequest += -(1.0 / source.Lambda) * Math.Log(_random.NextDouble());

        var generatedRequest = new Request(source.SourceId, source.SerialNumber, source.TimeOfNextRequest, -1);
        source.SerialNumber++;
        generatedRequest.SerialNumberOfSource = source.SerialNumber; // TODO REFACTOR? 

        _time.Now = source.TimeOfNextRequest;

        return generatedRequest;
    }
}