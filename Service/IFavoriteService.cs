using CamerounWonders.API.DTOs;

namespace CamerounWonders.API.Services;

public interface IFavoriteService
{
    Task<FavoriteDto> CreateAsync(
        CreateFavoriteDto dto,
        int userId);

    Task<List<FavoriteDto>>
        GetByUserAsync(
            int userId);

    Task RemoveAsync(
        int userId,
        int touristSiteId);
}