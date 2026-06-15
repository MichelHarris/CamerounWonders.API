using CamerounWonders.API.DTOs;

namespace CamerounWonders.API.Services;

public interface IRegionService
{
    Task<List<RegionDto>> GetAllAsync();

    Task<RegionDto?> GetByIdAsync(int id);

    Task<RegionDto> CreateAsync(CreateRegionDto dto);

    Task<bool> UpdateAsync(int id, UpdateRegionDto dto);

    Task<bool> DeleteAsync(int id);
}