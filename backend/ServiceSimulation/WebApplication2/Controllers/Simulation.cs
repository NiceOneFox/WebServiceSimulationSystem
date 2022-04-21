using Api.enums;
using Bll.Domain.Entities;
using Bll.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("simulation")]
public class Simulation : Controller
{
    private readonly ISimulationService _simulationService;

    public Simulation(ISimulationService simulationService)
    {
        _simulationService = simulationService;
    }

    [HttpGet("/start")]
    public IActionResult Start(InputParameters parameters)
    {
        _simulationService.StartSimulation(parameters);
        return Ok("Simulation answer");
    }
}