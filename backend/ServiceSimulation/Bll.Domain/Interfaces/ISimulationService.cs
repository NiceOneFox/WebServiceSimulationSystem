﻿using Bll.Domain.Models;

namespace Bll.Domain.Interfaces;

public interface ISimulationService
{
    void StartSimulation(InputParameters parameters);
}