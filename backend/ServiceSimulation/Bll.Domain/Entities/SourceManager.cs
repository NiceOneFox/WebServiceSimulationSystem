using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class SourceManager : ISourceManager
{
    public ITimeProvider Time { get; set; }
    public double TimeOfNextRequest { get; set; }
    public double Lambda { get; set; }

    private static Random _random = new();
    public SourceManager(ITimeProvider time)
    {
        Time = time;
    }

    public Request GetNewRequest(Source source)
    {
        TimeOfNextRequest += -(1.0 / Lambda) * Math.Log(_random.NextDouble());

        var generatedRequest = new Request(source.SourceId, source.SerialNumber, TimeOfNextRequest, -1);
        source.SerialNumber++;

        return generatedRequest;
    }
}