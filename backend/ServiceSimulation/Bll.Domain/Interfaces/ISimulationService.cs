using Api.enums;
using Bll.Domain.Entities;

namespace Bll.Domain.Interfaces;

public interface ISimulationService
{
    void StartSimulation(InputParameters parameters);
}