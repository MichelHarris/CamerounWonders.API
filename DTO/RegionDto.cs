namespace CamerounWonders.API.DTOs;

public class RegionDto
{
    public int Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string? PhotoUrl { get; set; }
}