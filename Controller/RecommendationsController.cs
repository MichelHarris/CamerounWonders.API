using CamerounWonders.API.DTOs;
using CamerounWonders.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CamerounWonders.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecommendationsController
    : ControllerBase
{
    private readonly IRecommendationService
        _service;

    public RecommendationsController(
        IRecommendationService service)
    {
        _service = service;
    }

    [HttpGet("home")]
    public async Task<
        ActionResult<HomeRecommendationsDto>>
        GetHomeRecommendations()
    {
        var result =
            await _service
                .GetHomeRecommendationsAsync();

        return Ok(result);
    }
}