using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class TimeProvider : ITimeProvider
{
    public double Now { get; set; }
}