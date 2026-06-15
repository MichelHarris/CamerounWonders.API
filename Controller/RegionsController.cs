using CamerounWonders.API.DTOs;
using CamerounWonders.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace CamerounWonders.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionsController : ControllerBase
{
    private readonly IRegionService _service;

    public RegionsController(IRegionService service)
    {
        _service = service;
    }

    // Accessible à tout le monde
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<List<RegionDto>>> GetAll()
    {
        var regions = await _service.GetAllAsync();
        return Ok(regions);
    }

    // Accessible à tout le monde
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<RegionDto>> GetById(int id)
    {
        var region = await _service.GetByIdAsync(id);

        if (region == null)
            return NotFound();

        return Ok(region);
    }

    // Réservé aux admins
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<RegionDto>> Create(CreateRegionDto dto)
    {
        var region = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = region.Id },
            region);
    }

    // Réservé aux admins
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateRegionDto dto)
    {
        var success = await _service.UpdateAsync(id, dto);

        if (!success)
            return NotFound();

        return NoContent();
    }

    // Réservé aux admins
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}