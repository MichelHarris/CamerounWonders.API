using CamerounWonders.API.DTOs;
using CamerounWonders.API.Models;
using CamerounWonders.API.Repositories;

namespace CamerounWonders.API.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _repository;

    public ReviewService(
        IReviewRepository repository)
    {
        _repository = repository;
    }

    public async Task<ReviewDto> CreateAsync(
        CreateReviewDto dto,
        int userId)
    {
        var review = new Review
        {
            TouristSiteId = dto.TouristSiteId,
            Rating = dto.Rating,
            Comment = dto.Comment,
            UserId = userId
        };

        review = await _repository
            .CreateAsync(review);

        return new ReviewDto
        {
            Id = review.Id,
            Rating = review.Rating,
            Comment = review.Comment,
            TouristSiteId = review.TouristSiteId,
            CreatedAt = review.CreatedAt
        };
    }

    public async Task<List<ReviewDto>>
        GetByTouristSiteAsync(
            int touristSiteId)
    {
        var reviews =
            await _repository
                .GetByTouristSiteAsync(
                    touristSiteId);

        return reviews
            .Select(r => new ReviewDto
            {
                Id = r.Id,
                Rating = r.Rating,
                Comment = r.Comment,
                Username =
                    r.User?.Username
                    ?? string.Empty,
                TouristSiteId =
                    r.TouristSiteId,
                CreatedAt =
                    r.CreatedAt
            })
            .ToList();
    }

    public async Task<double>
        GetAverageRatingAsync(
            int touristSiteId)
    {
        return await _repository
            .GetAverageRatingAsync(
                touristSiteId);
    }
}