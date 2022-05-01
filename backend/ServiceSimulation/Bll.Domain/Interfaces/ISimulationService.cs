using Bll.Domain.Models;

namespace Bll.Domain.Interfaces;

public interface ISimulationService
{
    Task StartSimulation(InputParameters parameters);
}