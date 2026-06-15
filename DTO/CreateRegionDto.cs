namespace CamerounWonders.API.DTOs;

public class CreateRegionDto
{
    public string Nom { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string? PhotoUrl { get; set; }
}