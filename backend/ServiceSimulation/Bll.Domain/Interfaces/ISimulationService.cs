using Bll.Domain.Models;

namespace Bll.Domain.Interfaces;

public interface ISimulationService
{
    Task StartSimulationAsync(InputParameters parameters);
}