using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class Results : IResults
{
    public List<Request> Cancelled { get; set; } = new();
    public List<Request> Processed { get; set; } = new();
    public double ModelingTime { get; set; }
    public int AmountOfServedRequest { get; set; }
}