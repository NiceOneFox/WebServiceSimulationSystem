using Bll.Domain.Entities;

namespace Bll.Domain.Interfaces;

public interface IResults
{
    public List<Request> Cancelled { get; set; }
    public List<Request> Processed { get; set; }
    double ModelingTime { get; set; }
}