namespace CamerounWonders.API.DTOs;

public class MostFavoritedSiteDto
{
    public int TouristSiteId { get; set; }

    public string Name { get; set; }
        = string.Empty;

    public int FavoritesCount { get; set; }
}