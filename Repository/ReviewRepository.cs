using CamerounWonders.API.Data;
using CamerounWonders.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CamerounWonders.API.Repositories;

public class ReviewRepository
    : IReviewRepository
{
    private readonly ApplicationDbContext _context;

    public ReviewRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Review> CreateAsync(
        Review review)
    {
        _context.Reviews.Add(review);

        await _context.SaveChangesAsync();

        return review;
    }

    public async Task<List<Review>>
        GetByTouristSiteAsync(
            int touristSiteId)
    {
        return await _context.Reviews
            .Include(r => r.User)
            .Where(r =>
                r.TouristSiteId ==
                touristSiteId)
            .OrderByDescending(r =>
                r.CreatedAt)
            .ToListAsync();
    }

    public async Task<double>
        GetAverageRatingAsync(
            int touristSiteId)
    {
        var reviews =
            _context.Reviews
                .Where(r =>
                    r.TouristSiteId ==
                    touristSiteId);

        if (!await reviews.AnyAsync())
            return 0;

        return await reviews
            .AverageAsync(r =>
                r.Rating);
    }
}