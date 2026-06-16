using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CamerounWonders.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public UploadController(
        IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> UploadImage(
        IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("Aucun fichier envoyé.");
        }

        var uploadsFolder =
            Path.Combine(
                _environment.WebRootPath,
                "uploads");

        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(
                uploadsFolder);
        }

        var fileName =
            $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        var filePath =
            Path.Combine(
                uploadsFolder,
                fileName);

        using var stream =
            new FileStream(
                filePath,
                FileMode.Create);

        await file.CopyToAsync(stream);

        var imageUrl =
            $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";

        return Ok(new
        {
            imageUrl
        });
    }
}