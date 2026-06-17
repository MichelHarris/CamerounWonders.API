namespace CamerounWonders.API.DTOs;

public class TouristSiteDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public int RegionId { get; set; }

    public string RegionName { get; set; } = string.Empty;

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}