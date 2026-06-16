namespace CamerounWonders.API.DTOs;

public class FavoriteDto
{
    public int Id { get; set; }

    public int TouristSiteId { get; set; }

    public string TouristSiteName { get; set; }
        = string.Empty;

    public string TouristSiteImageUrl { get; set; }
        = string.Empty;

    public DateTime CreatedAt { get; set; }
}