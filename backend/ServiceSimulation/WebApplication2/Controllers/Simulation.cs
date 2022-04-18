using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("simulation")]
public class Simulation : Controller
{
    [HttpGet("/start")]
    public IActionResult Start()
    {
        return Ok("Simulation answer");
    }
}