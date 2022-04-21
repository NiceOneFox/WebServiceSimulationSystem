namespace Bll.Domain.Entities;

public class Results
{
    public List<Request> Cancelled = new();

    public List<Request> Processed = new();
    public double ModelingTime { get; set; }
}