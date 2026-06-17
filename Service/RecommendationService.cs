using CamerounWonders.API.DTOs;
using CamerounWonders.API.Repositories;

namespace CamerounWonders.API.Services;

public class RecommendationService
    : IRecommendationService
{
    private readonly IDashboardRepository
        _dashboardRepository;

    public RecommendationService(
        IDashboardRepository
            dashboardRepository)
    {
        _dashboardRepository =
            dashboardRepository;
    }

    public async Task<HomeRecommendationsDto>
        GetHomeRecommendationsAsync()
    {
        return new HomeRecommendationsDto
        {
            TopRatedSites =
                await _dashboardRepository
                    .GetTopRatedSitesAsync(),

            MostFavoritedSites =
                await _dashboardRepository
                    .GetMostFavoritedSitesAsync(),

            RecentSites =
                await _dashboardRepository
                    .GetRecentSitesAsync()
        };
    }
}