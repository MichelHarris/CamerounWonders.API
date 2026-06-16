using CamerounWonders.API.Models;

namespace CamerounWonders.API.Repositories;

public interface IFavoriteRepository
{
    Task<Favorite> CreateAsync(
        Favorite favorite);

    Task<List<Favorite>>
        GetByUserAsync(
            int userId);

    Task<Favorite?>
        GetByUserAndSiteAsync(
            int userId,
            int touristSiteId);

    Task DeleteAsync(
        Favorite favorite);
}