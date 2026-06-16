using CamerounWonders.API.DTOs;

namespace CamerounWonders.API.Services;

public interface IDashboardService
{
    Task<DashboardStatsDto> GetStatsAsync();
}