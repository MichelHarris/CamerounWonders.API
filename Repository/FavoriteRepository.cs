using CamerounWonders.API.Data;
using CamerounWonders.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CamerounWonders.API.Repositories;

public class FavoriteRepository
    : IFavoriteRepository
{
    private readonly ApplicationDbContext _context;

    public FavoriteRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Favorite>
        CreateAsync(Favorite favorite)
    {
        _context.Favorites.Add(favorite);

        await _context.SaveChangesAsync();

        return favorite;
    }

    public async Task<List<Favorite>>
        GetByUserAsync(int userId)
    {
        return await _context.Favorites
            .Include(f => f.TouristSite)
            .Where(f => f.UserId == userId)
            .OrderByDescending(f => f.CreatedAt)
            .ToListAsync();
    }

    public async Task<Favorite?>
        GetByUserAndSiteAsync(
            int userId,
            int touristSiteId)
    {
        return await _context.Favorites
            .FirstOrDefaultAsync(f =>
                f.UserId == userId &&
                f.TouristSiteId == touristSiteId);
    }

    public async Task DeleteAsync(
        Favorite favorite)
    {
        _context.Favorites.Remove(favorite);

        await _context.SaveChangesAsync();
    }
}