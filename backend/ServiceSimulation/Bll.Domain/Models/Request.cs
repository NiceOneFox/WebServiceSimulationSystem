namespace Bll.Domain.Models;

public class Request
{
    public int NumberOfSource { get; set; }
    public int SerialNumberOfSource { get; set; }
    public double StartTime { get; set; }
    public double? EndTime { get; set; }

    public Request(int numberOfSource, int serialNumberOfSource, double startTime, double? endTime)
    {
        NumberOfSource = numberOfSource;
        SerialNumberOfSource = serialNumberOfSource;
        StartTime = startTime;
        EndTime = endTime;
    }

    public override string ToString()
        => "Time: " + StartTime + " №sourceManager: " + NumberOfSource + "-" + SerialNumberOfSource;
}