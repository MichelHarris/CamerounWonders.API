using CamerounWonders.API.DTOs;
using CamerounWonders.API.Models;
using CamerounWonders.API.Repositories;

namespace CamerounWonders.API.Services;

public class FavoriteService
    : IFavoriteService
{
    private readonly IFavoriteRepository _repository;

    public FavoriteService(
        IFavoriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<FavoriteDto>
        CreateAsync(
            CreateFavoriteDto dto,
            int userId)
    {
        var existingFavorite =
            await _repository
                .GetByUserAndSiteAsync(
                    userId,
                    dto.TouristSiteId);

        if (existingFavorite != null)
        {
            throw new Exception(
                "Ce site est déjà dans vos favoris.");
        }

        var favorite = new Favorite
        {
            UserId = userId,
            TouristSiteId =
                dto.TouristSiteId
        };

        favorite =
            await _repository
                .CreateAsync(favorite);

        return new FavoriteDto
        {
            Id = favorite.Id,
            TouristSiteId =
                favorite.TouristSiteId,
            CreatedAt =
                favorite.CreatedAt
        };
    }

    public async Task<List<FavoriteDto>>
        GetByUserAsync(
            int userId)
    {
        var favorites =
            await _repository
                .GetByUserAsync(userId);

        return favorites
            .Select(f => new FavoriteDto
            {
                Id = f.Id,

                TouristSiteId =
                    f.TouristSiteId,

                TouristSiteName =
                    f.TouristSite?.Name
                    ?? string.Empty,

                TouristSiteImageUrl =
                    f.TouristSite?.ImageUrl
                    ?? string.Empty,

                CreatedAt =
                    f.CreatedAt
            })
            .ToList();
    }

    public async Task RemoveAsync(
        int userId,
        int touristSiteId)
    {
        var favorite =
            await _repository
                .GetByUserAndSiteAsync(
                    userId,
                    touristSiteId);

        if (favorite == null)
        {
            throw new Exception(
                "Favori introuvable.");
        }

        await _repository
            .DeleteAsync(favorite);
    }
}