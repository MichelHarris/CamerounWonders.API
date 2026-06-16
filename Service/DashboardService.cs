using CamerounWonders.API.DTOs;
using CamerounWonders.API.Repositories;

namespace CamerounWonders.API.Services;

public class DashboardService
    : IDashboardService
{
    private readonly IDashboardRepository _repository;

    public DashboardService(
        IDashboardRepository repository)
    {
        _repository = repository;
    }

    public async Task<DashboardStatsDto>
        GetStatsAsync()
    {
        return await _repository
            .GetStatsAsync();
    }
}