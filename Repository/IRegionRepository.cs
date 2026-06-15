using CamerounWonders.API.Models;

namespace CamerounWonders.API.Repositories;

public interface IRegionRepository
{
    Task<List<Region>> GetAllAsync();

    Task<Region?> GetByIdAsync(int id);

    Task<Region> CreateAsync(Region region);

    Task UpdateAsync(Region region);

    Task DeleteAsync(Region region);
}