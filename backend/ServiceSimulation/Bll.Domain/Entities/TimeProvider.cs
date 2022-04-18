using Bll.Domain.Interfaces;

namespace Bll.Domain.Entities;

public class TimeProvider : ITimeProvider
{
    public DateTime Now { get; } = DateTime.Now;
}