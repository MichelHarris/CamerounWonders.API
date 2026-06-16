using CamerounWonders.API.DTOs;
using CamerounWonders.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CamerounWonders.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FavoritesController : ControllerBase
{
    private readonly IFavoriteService _service;

    public FavoritesController(
        IFavoriteService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<FavoriteDto>>
        Create(CreateFavoriteDto dto)
    {
        var userIdClaim =
            User.FindFirst(
                ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        var userId =
            int.Parse(userIdClaim.Value);

        var favorite =
            await _service.CreateAsync(
                dto,
                userId);

        return Ok(favorite);
    }

    [HttpGet("my-favorites")]
    public async Task<ActionResult<List<FavoriteDto>>>
        GetMyFavorites()
    {
        var userIdClaim =
            User.FindFirst(
                ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        var userId =
            int.Parse(userIdClaim.Value);

        var favorites =
            await _service.GetByUserAsync(
                userId);

        return Ok(favorites);
    }

    [HttpDelete("{touristSiteId}")]
    public async Task<IActionResult>
        Remove(int touristSiteId)
    {
        var userIdClaim =
            User.FindFirst(
                ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        var userId =
            int.Parse(userIdClaim.Value);

        await _service.RemoveAsync(
            userId,
            touristSiteId);

        return NoContent();
    }
}