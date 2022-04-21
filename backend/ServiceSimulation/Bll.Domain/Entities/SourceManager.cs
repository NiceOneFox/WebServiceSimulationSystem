using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class SourceManager : ISourceManager
{
    public ITimeProvider Time { get; set; }
    public SourceManager(ITimeProvider time)
    {
        Time = time;
    }

    public Request GetNewRequest(Source source)
    {
        var generatedRequest = new Request(source.SourceId, source.SerialNumber, Time.Now, Time.Now + 0.11);
        source.SerialNumber++;
        return generatedRequest;
    }
}