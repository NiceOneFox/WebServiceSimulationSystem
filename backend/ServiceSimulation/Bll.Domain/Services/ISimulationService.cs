using Api.enums;

namespace Bll.Domain.Services;

public interface ISimulationService
{
    void StartSimulation(SimulationType simulationType);
}