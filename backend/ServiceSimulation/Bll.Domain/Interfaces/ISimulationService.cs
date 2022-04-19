using Api.enums;

namespace Bll.Domain.Interfaces;

public interface ISimulationService
{
    void StartSimulation(SimulationType simulationType);
}