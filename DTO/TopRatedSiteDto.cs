namespace CamerounWonders.API.DTOs;

public class TopRatedSiteDto
{
    public int TouristSiteId { get; set; }

    public string Name { get; set; }
        = string.Empty;

    public double AverageRating { get; set; }
}