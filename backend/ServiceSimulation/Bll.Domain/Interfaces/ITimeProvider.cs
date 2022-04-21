namespace Bll.Domain.Interfaces;

public interface ITimeProvider
{
    double Now { get; }
}