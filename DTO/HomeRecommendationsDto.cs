namespace CamerounWonders.API.DTOs;

public class HomeRecommendationsDto
{
    public List<TopRatedSiteDto>
        TopRatedSites
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

    public List<TouristSiteDto>
        RecentSites
    {
        get;
        set;
    }
    = new();
}