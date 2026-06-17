using CamerounWonders.API.DTOs;

namespace CamerounWonders.API.Services;

public interface ITouristSiteService
{
    Task<List<TouristSiteDto>> GetAllAsync();

    Task<TouristSiteDto?> GetByIdAsync(int id);

    Task<List<TouristSiteDto>> GetByRegionIdAsync(int regionId);

    Task<TouristSiteDto> CreateAsync(CreateTouristSiteDto dto);

    Task<bool> UpdateAsync(int id, UpdateTouristSiteDto dto);

    Task<bool> DeleteAsync(int id);
    Task<List<TouristSiteDto>> SearchAsync(
    string? name,
    int? regionId);
    Task<List<NearbyTouristSiteDto>>
    GetNearbyAsync(
        NearbySearchDto dto);
}