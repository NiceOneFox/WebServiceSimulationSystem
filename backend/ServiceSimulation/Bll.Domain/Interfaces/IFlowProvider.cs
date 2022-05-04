namespace Bll.Domain.Interfaces
{
    public interface IFlowProvider
    {
        double GetInterval(double currentTime, double lambda);
    }
}
