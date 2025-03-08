using BlogAPI.DTOs;
using BlogAPI.Models;
using System.Threading.Tasks;

namespace BlogAPI.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponse> LoginAsync(LoginDto loginDto);
        string GenerateJwtToken(User user);
    }
}