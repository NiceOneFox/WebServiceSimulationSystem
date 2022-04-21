using Api.enums;
using Bll.Domain.Entities;
using Bll.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("simulation")]
public class Simulation : Controller
{
    private readonly ISimulationService _simulationService;

    private readonly ITimeProvider _time;

    public Simulation(ISimulationService simulationService, ITimeProvider time)
    {
        _simulationService = simulationService;
        _time = time;
    }

    [HttpGet("/start")]
    public IActionResult Start(InputParameters parameters)
    {
        _time.Now = 0.4;
        _simulationService.StartSimulation(parameters);
        return Ok($"Simulation answer: Time: {_time.Now}");
    }
}