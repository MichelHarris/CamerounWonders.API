namespace CamerounWonders.API.DTOs;

public class DashboardStatsDto
{
    public int TotalUsers { get; set; }

    public int TotalRegions { get; set; }

    public int TotalTouristSites { get; set; }

    public int TotalReviews { get; set; }

    public int TotalFavorites { get; set; }

    public double AverageRating { get; set; }

    public List<TopRatedSiteDto> TopRatedSites
    {
        get;
        set;
    }
    = new();

    public List<MostFavoritedSiteDto>
        MostFavoritedSites
    {
        get;
        set;
    }
    = new();
}