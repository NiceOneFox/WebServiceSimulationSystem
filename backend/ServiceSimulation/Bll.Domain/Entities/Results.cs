using Bll.Domain.Interfaces;
using Bll.Domain.Models;

namespace Bll.Domain.Entities;

public class Results : IResults
{
    public List<Request> Cancelled { get; set; } = new();
    public List<Request> Processed { get; set; } = new();
    public double ModelingTime { get; set; }
    public int AmountOfGeneratedRequests { get; set; }
    public int AmountOfServedRequest
    {
        get => Cancelled.Count + Processed.Count;
        set { }
    }
}