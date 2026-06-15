using CamerounWonders.API.Data;
using CamerounWonders.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CamerounWonders.API.Repositories;

public class TouristSiteRepository : ITouristSiteRepository
{
    private readonly ApplicationDbContext _context;

    public TouristSiteRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TouristSite>> GetAllAsync()
    {
        return await _context.TouristSites
            .Include(t => t.Region)
            .ToListAsync();
    }

    public async Task<TouristSite?> GetByIdAsync(int id)
    {
        return await _context.TouristSites
            .Include(t => t.Region)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<TouristSite>> GetByRegionIdAsync(
        int regionId)
    {
        return await _context.TouristSites
            .Include(t => t.Region)
            .Where(t => t.RegionId == regionId)
            .ToListAsync();
    }

    public async Task<TouristSite> CreateAsync(
        TouristSite touristSite)
    {
        _context.TouristSites.Add(touristSite);

        await _context.SaveChangesAsync();

        return touristSite;
    }

    public async Task UpdateAsync(
        TouristSite touristSite)
    {
        _context.TouristSites.Update(touristSite);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(
        TouristSite touristSite)
    {
        _context.TouristSites.Remove(touristSite);

        await _context.SaveChangesAsync();
    }
}