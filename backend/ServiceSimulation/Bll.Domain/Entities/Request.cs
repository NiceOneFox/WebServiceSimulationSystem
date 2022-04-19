namespace Bll.Domain.Entities;

public class Request
{
    public int NumberOfSource { get; set; }
    public int SerialNumberOfSource { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public Request(int numberOfSource, int serialNumberOfSource, DateTime startTime, DateTime endTime)
    {
        NumberOfSource = numberOfSource;
        SerialNumberOfSource = serialNumberOfSource;
        StartTime = startTime;
        EndTime = endTime;
    }

    public override string ToString()
        => "Time: " + StartTime + " №sourceManager: " + NumberOfSource + "-" + SerialNumberOfSource;
}