namespace CamerounWonders.API.DTOs;

public class UpdateTouristSiteDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public int RegionId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}