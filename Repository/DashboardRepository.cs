using CamerounWonders.API.Data;
using CamerounWonders.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CamerounWonders.API.Repositories;

public class DashboardRepository
    : IDashboardRepository
{
    private readonly ApplicationDbContext _context;

    public DashboardRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardStatsDto>
        GetStatsAsync()
    {
        var totalUsers =
            await _context.Users.CountAsync();

        var totalRegions =
            await _context.Regions.CountAsync();

        var totalTouristSites =
            await _context.TouristSites.CountAsync();

        var totalReviews =
            await _context.Reviews.CountAsync();

        var totalFavorites =
            await _context.Favorites.CountAsync();

        double averageRating = 0;

        if (await _context.Reviews.AnyAsync())
        {
            averageRating =
                await _context.Reviews
                    .AverageAsync(r => r.Rating);
        }
        var topRatedSites =
    await GetTopRatedSitesAsync();

        var mostFavoritedSites =
            await GetMostFavoritedSitesAsync();
        return new DashboardStatsDto
        {
            TotalUsers = totalUsers,
            TotalRegions = totalRegions,
            TotalTouristSites = totalTouristSites,
            TotalReviews = totalReviews,
            TotalFavorites = totalFavorites,
            AverageRating = Math.Round(
        averageRating,
        2),

            TopRatedSites =
        topRatedSites,

            MostFavoritedSites =
        mostFavoritedSites
        };
    }
    public async Task<List<TopRatedSiteDto>>
    GetTopRatedSitesAsync()
    {
        return await _context.Reviews
            .Include(r => r.TouristSite)
            .GroupBy(r => new
            {
                r.TouristSiteId,
                r.TouristSite!.Name
            })
            .Select(g => new TopRatedSiteDto
            {
                TouristSiteId =
                    g.Key.TouristSiteId,

                Name =
                    g.Key.Name,

                AverageRating =
                    g.Average(r =>
                        r.Rating)
            })
            .OrderByDescending(x =>
                x.AverageRating)
            .Take(5)
            .ToListAsync();
    }
    public async Task<List<MostFavoritedSiteDto>>
    GetMostFavoritedSitesAsync()
    {
        return await _context.Favorites
            .Include(f => f.TouristSite)
            .GroupBy(f => new
            {
                f.TouristSiteId,
                f.TouristSite!.Name
            })
            .Select(g => new MostFavoritedSiteDto
            {
                TouristSiteId =
                    g.Key.TouristSiteId,

                Name =
                    g.Key.Name,

                FavoritesCount =
                    g.Count()
            })
            .OrderByDescending(x =>
                x.FavoritesCount)
            .Take(5)
            .ToListAsync();
    }
    public async Task<List<TouristSiteDto>>
    GetRecentSitesAsync()
    {
        return await _context.TouristSites
            .Include(t => t.Region)
            .OrderByDescending(t => t.Id)
            .Take(5)
            .Select(t => new TouristSiteDto
            {
                Id = t.Id,

                Name = t.Name,

                Description =
                    t.Description,

                Location =
                    t.Location,

                ImageUrl =
                    t.ImageUrl,

                RegionId =
                    t.RegionId,

                RegionName =
                    t.Region != null
                        ? t.Region.Nom
                        : string.Empty
            })
            .ToListAsync();
    }
}