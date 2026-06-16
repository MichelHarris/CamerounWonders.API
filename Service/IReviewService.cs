using CamerounWonders.API.DTOs;

namespace CamerounWonders.API.Services;

public interface IReviewService
{
    Task<ReviewDto> CreateAsync(
        CreateReviewDto dto,
        int userId);

    Task<List<ReviewDto>>
        GetByTouristSiteAsync(
            int touristSiteId);

    Task<double>
        GetAverageRatingAsync(
            int touristSiteId);
}