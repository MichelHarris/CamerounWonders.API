using CamerounWonders.API.Models;

namespace CamerounWonders.API.Repositories;

public interface ITouristSiteRepository
{
    Task<List<TouristSite>> GetAllAsync();

    Task<TouristSite?> GetByIdAsync(int id);

    Task<List<TouristSite>> GetByRegionIdAsync(int regionId);

    Task<TouristSite> CreateAsync(TouristSite touristSite);

    Task UpdateAsync(TouristSite touristSite);

    Task DeleteAsync(TouristSite touristSite);
    Task<List<TouristSite>> SearchAsync(
    string? name,
    int? regionId);
}