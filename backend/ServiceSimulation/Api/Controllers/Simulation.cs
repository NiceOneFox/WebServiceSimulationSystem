using Api.Entities;
using Api.Validation;
using AutoMapper;
using Bll.Domain.Interfaces;
using Bll.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("simulation")]
public class Simulation : Controller
{
    private readonly ISimulationService _simulationService;
    private readonly ITimeProvider _time;
    private readonly IResults _results;
    private readonly IResultManager _resultManager;
    private readonly IMapper _mapper;
    public Simulation(ISimulationService simulationService,
        ITimeProvider time,
        IResults results,
        IResultManager resultManager,
        IMapper mapper)
    {
        _simulationService = simulationService;
        _time = time;
        _results = results;
        _resultManager = resultManager;
        _mapper = mapper;
    }

    [HttpGet("/start")]
    public async Task<IActionResult> Start(InputParameters parameters)
    {
        new InputParametersValidator().ValidateAndThrow(parameters);

        await _simulationService.StartSimulationAsync(parameters);
        var endResultsOfModeling = _resultManager.CalculateResultsOfModeling();
        var apiResults = _mapper.Map<ApiResults>((endResultsOfModeling, _results));

        return Ok(apiResults);
    }
}