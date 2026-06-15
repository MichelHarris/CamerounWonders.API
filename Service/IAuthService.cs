using CamerounWonders.API.DTOs;

namespace CamerounWonders.API.Services;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto dto);

    Task<string> LoginAsync(LoginDto dto);
}