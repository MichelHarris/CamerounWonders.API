using CamerounWonders.API.DTOs;

namespace CamerounWonders.API.Services;

public interface IRecommendationService
{
    Task<HomeRecommendationsDto>
        GetHomeRecommendationsAsync();
}