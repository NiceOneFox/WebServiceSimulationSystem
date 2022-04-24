using Bll.Domain.Entities;

namespace Bll.Domain.Interfaces;

public interface IResults
{
    List<Request> Cancelled { get; set; }
    List<Request> Processed { get; set; }
    double ModelingTime { get; set; }
    int AmountOfGeneratedRequests { get; set; }
    int AmountOfServedRequest { get; set; }
}