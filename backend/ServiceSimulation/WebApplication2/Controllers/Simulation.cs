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
    private readonly IResults _results;

    public Simulation(ISimulationService simulationService, ITimeProvider time, IResults results)
    {
        _simulationService = simulationService;
        _time = time;
        _results = results;
    }

    [HttpGet("/start")]
    public IActionResult Start(InputParameters parameters)
    {
        _time.Now = 0.4;
        _simulationService.StartSimulation(parameters);
        return Ok($"Simulation answer: Time: {_time.Now}");
    }
}