using CamerounWonders.API.DTOs;
using CamerounWonders.API.Models;
using CamerounWonders.API.Repositories;

namespace CamerounWonders.API.Services;

public class RegionService : IRegionService
{
    private readonly IRegionRepository _repository;

    public RegionService(IRegionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<RegionDto>> GetAllAsync()
    {
        var regions = await _repository.GetAllAsync();

        return regions.Select(r => new RegionDto
        {
            Id = r.Id,
            Nom = r.Nom,
            Description = r.Description,
            PhotoUrl = r.PhotoUrl
        }).ToList();
    }

    public async Task<RegionDto?> GetByIdAsync(int id)
    {
        var region = await _repository.GetByIdAsync(id);

        if (region == null)
            return null;

        return new RegionDto
        {
            Id = region.Id,
            Nom = region.Nom,
            Description = region.Description,
            PhotoUrl = region.PhotoUrl
        };
    }

    public async Task<RegionDto> CreateAsync(CreateRegionDto dto)
    {
        var region = new Region
        {
            Nom = dto.Nom,
            Description = dto.Description,
            PhotoUrl = dto.PhotoUrl
        };

        await _repository.CreateAsync(region);

        return new RegionDto
        {
            Id = region.Id,
            Nom = region.Nom,
            Description = region.Description,
            PhotoUrl = region.PhotoUrl
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateRegionDto dto)
    {
        var region = await _repository.GetByIdAsync(id);

        if (region == null)
            return false;

        region.Nom = dto.Nom;
        region.Description = dto.Description;
        region.PhotoUrl = dto.PhotoUrl;

        await _repository.UpdateAsync(region);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var region = await _repository.GetByIdAsync(id);

        if (region == null)
            return false;

        await _repository.DeleteAsync(region);

        return true;
    }
}