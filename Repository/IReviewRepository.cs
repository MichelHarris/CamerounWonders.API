using CamerounWonders.API.Models;

namespace CamerounWonders.API.Repositories;

public interface IReviewRepository
{
    Task<Review> CreateAsync(Review review);

    Task<List<Review>> GetByTouristSiteAsync(
        int touristSiteId);

    Task<double> GetAverageRatingAsync(
        int touristSiteId);
}