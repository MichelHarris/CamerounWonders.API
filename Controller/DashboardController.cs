using CamerounWonders.API.DTOs;
using CamerounWonders.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CamerounWonders.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _service;

    public DashboardController(
        IDashboardService service)
    {
        _service = service;
    }

    [HttpGet("stats")]
    public async Task<ActionResult<DashboardStatsDto>>
        GetStats()
    {
        var stats =
            await _service
                .GetStatsAsync();

        return Ok(stats);
    }
}