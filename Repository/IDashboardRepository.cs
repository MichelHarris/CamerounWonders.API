using CamerounWonders.API.DTOs;

namespace CamerounWonders.API.Repositories;

public interface IDashboardRepository
{
    Task<DashboardStatsDto> GetStatsAsync();
    Task<List<TopRatedSiteDto>>
    GetTopRatedSitesAsync();

    Task<List<MostFavoritedSiteDto>>
        GetMostFavoritedSitesAsync();
}