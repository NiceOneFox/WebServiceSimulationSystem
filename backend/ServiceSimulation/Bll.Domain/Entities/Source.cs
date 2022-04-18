using Bll.Domain.Interfaces;
using Bll.Domain.Services;

namespace Bll.Domain.Entities;

public class Source : ISource
{
    public int SourceId { get; set; }
    public int Priority { get; set; }
    public int SerialNumber { get; set; }
    public ITimeProvider Time { get; set; }
    public Source(int sourceId, int priority, int serialNumber, ITimeProvider time)
    {
        SourceId = sourceId;
        Priority = priority;
        SerialNumber = serialNumber;
        Time = time;
    }

    public Request GetNewRequest()
    {
        var generatedRequest = new Request(SourceId, SerialNumber, Time.Now, DateTime.Now.AddMilliseconds(5.0));
        SerialNumber++;
        return generatedRequest;
    }
}