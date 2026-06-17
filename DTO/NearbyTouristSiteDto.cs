namespace CamerounWonders.API.DTOs;

public class NearbyTouristSiteDto
{
    public int Id { get; set; }

    public string Name { get; set; }
        = string.Empty;

    public string Location { get; set; }
        = string.Empty;

    public string RegionName { get; set; }
        = string.Empty;

    public string? ImageUrl { get; set; }

    public double AverageRating { get; set; }

    public int FavoritesCount { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public double DistanceKm { get; set; }
}