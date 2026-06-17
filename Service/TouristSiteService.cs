using CamerounWonders.API.DTOs;
using CamerounWonders.API.Models;
using CamerounWonders.API.Repositories;

namespace CamerounWonders.API.Services;

public class TouristSiteService : ITouristSiteService
{
    private readonly ITouristSiteRepository _repository;

    public TouristSiteService(
        ITouristSiteRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TouristSiteDto>> GetAllAsync()
    {
        var sites = await _repository.GetAllAsync();

        return sites.Select(MapToDto).ToList();
    }

    public async Task<TouristSiteDto?> GetByIdAsync(int id)
    {
        var site = await _repository.GetByIdAsync(id);

        return site == null
            ? null
            : MapToDto(site);
    }

    public async Task<List<TouristSiteDto>>
        GetByRegionIdAsync(int regionId)
    {
        var sites =
            await _repository.GetByRegionIdAsync(regionId);

        return sites.Select(MapToDto).ToList();
    }

    public async Task<TouristSiteDto> CreateAsync(
        CreateTouristSiteDto dto)
    {
        var site = new TouristSite
        {
            Name = dto.Name,
            Description = dto.Description,
            Location = dto.Location,
            ImageUrl = dto.ImageUrl ?? string.Empty,
            RegionId = dto.RegionId,

            Latitude = dto.Latitude,
            Longitude = dto.Longitude
        };

        var created =
            await _repository.CreateAsync(site);

        var createdSite =
            await _repository.GetByIdAsync(created.Id);

        return MapToDto(createdSite!);
    }

    public async Task<bool> UpdateAsync(
        int id,
        UpdateTouristSiteDto dto)
    {
        var site =
            await _repository.GetByIdAsync(id);

        if (site == null)
            return false;

        site.Name = dto.Name;
        site.Description = dto.Description;
        site.Location = dto.Location;
        site.ImageUrl = dto.ImageUrl ?? string.Empty;
        site.RegionId = dto.RegionId;
        site.Latitude = dto.Latitude;
        site.Longitude = dto.Longitude;

        await _repository.UpdateAsync(site);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var site =
            await _repository.GetByIdAsync(id);

        if (site == null)
            return false;

        await _repository.DeleteAsync(site);

        return true;
    }

    private static TouristSiteDto MapToDto(
        TouristSite site)
    {
        return new TouristSiteDto
        {
            Id = site.Id,
            Name = site.Name,
            Description = site.Description,
            Location = site.Location,
            ImageUrl = site.ImageUrl,
            RegionId = site.RegionId,
            RegionName = site.Region?.Nom ?? string.Empty,

            Latitude = site.Latitude,
            Longitude = site.Longitude
        };
    }

    public async Task<List<TouristSiteDto>> SearchAsync(
    string? name,
    int? regionId)
    {
        var sites =
            await _repository.SearchAsync(
                name,
                regionId);

        return sites
            .Select(MapToDto)
            .ToList();
    }
}