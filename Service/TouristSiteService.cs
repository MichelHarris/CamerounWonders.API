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

    public async Task<List<NearbyTouristSiteDto>>
    GetNearbyAsync(
        NearbySearchDto dto)
    {
        var sites =
            await _repository.GetAllAsync();

        var result =
            sites.Select(site =>
            {
                var distance =
                    CalculateDistance(
                        dto.Latitude,
                        dto.Longitude,
                        site.Latitude,
                        site.Longitude);

                return new NearbyTouristSiteDto
                {
                    Id = site.Id,
                    Name = site.Name,
                    Location = site.Location,
                    Latitude = site.Latitude,
                    Longitude = site.Longitude,
                    DistanceKm = Math.Round(
                        distance,
                        2)
                };
            })
            .Where(x =>
                x.DistanceKm <= dto.RadiusKm)
            .OrderBy(x =>
                x.DistanceKm)
            .ToList();

        return result;
    }
    private static double CalculateDistance(
    double lat1,
    double lon1,
    double lat2,
    double lon2)
    {
        const double earthRadiusKm = 6371;

        var dLat =
            DegreesToRadians(
                lat2 - lat1);

        var dLon =
            DegreesToRadians(
                lon2 - lon1);

        var a =
            Math.Sin(dLat / 2) *
            Math.Sin(dLat / 2)
            +
            Math.Cos(
                DegreesToRadians(lat1))
            *
            Math.Cos(
                DegreesToRadians(lat2))
            *
            Math.Sin(dLon / 2)
            *
            Math.Sin(dLon / 2);

        var c =
            2 *
            Math.Atan2(
                Math.Sqrt(a),
                Math.Sqrt(1 - a));

        return earthRadiusKm * c;
    }
    private static double DegreesToRadians(
    double degrees)
    {
        return degrees *
            (Math.PI / 180);
    }
}

