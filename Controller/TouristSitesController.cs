using CamerounWonders.API.DTOs;
using CamerounWonders.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CamerounWonders.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TouristSitesController : ControllerBase
{
    private readonly ITouristSiteService _service;

    public TouristSitesController(
        ITouristSiteService service)
    {
        _service = service;
    }

    // Public
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<List<TouristSiteDto>>>
        GetAll()
    {
        var sites = await _service.GetAllAsync();

        return Ok(sites);
    }

    [AllowAnonymous]
    [HttpGet("search")]
    public async Task<ActionResult<List<TouristSiteDto>>>
    Search(
        [FromQuery] string? name,
        [FromQuery] int? regionId)
    {
        var sites =
            await _service.SearchAsync(
                name,
                regionId);

        return Ok(sites);
    }

    // Public
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<TouristSiteDto>>
        GetById(int id)
    {
        var site = await _service.GetByIdAsync(id);

        if (site == null)
            return NotFound();

        return Ok(site);
    }

    // Public
    [AllowAnonymous]
    [HttpGet("region/{regionId}")]
    public async Task<ActionResult<List<TouristSiteDto>>>
        GetByRegion(int regionId)
    {
        var sites =
            await _service.GetByRegionIdAsync(regionId);

        return Ok(sites);
    }

    // Admin uniquement
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<TouristSiteDto>>
        Create(CreateTouristSiteDto dto)
    {
        var site =
            await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = site.Id },
            site);
    }

    // Admin uniquement
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult>
        Update(
            int id,
            UpdateTouristSiteDto dto)
    {
        var success =
            await _service.UpdateAsync(id, dto);

        if (!success)
            return NotFound();

        return NoContent();
    }

    // Admin uniquement
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult>
        Delete(int id)
    {
        var success =
            await _service.DeleteAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}