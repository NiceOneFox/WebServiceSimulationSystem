namespace Bll.Domain.Interfaces;

public interface ITimeProvider
{
    DateTime Now { get; }
}