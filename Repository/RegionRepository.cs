using CamerounWonders.API.Data;
using CamerounWonders.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CamerounWonders.API.Repositories;

public class RegionRepository : IRegionRepository
{
    private readonly ApplicationDbContext _context;

    public RegionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Region>> GetAllAsync()
    {
        return await _context.Regions.ToListAsync();
    }

    public async Task<Region?> GetByIdAsync(int id)
    {
        return await _context.Regions.FindAsync(id);
    }

    public async Task<Region> CreateAsync(Region region)
    {
        _context.Regions.Add(region);

        await _context.SaveChangesAsync();

        return region;
    }

    public async Task UpdateAsync(Region region)
    {
        _context.Regions.Update(region);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Region region)
    {
        _context.Regions.Remove(region);

        await _context.SaveChangesAsync();
    }
}