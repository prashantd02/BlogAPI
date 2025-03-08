using BlogAPI.DTOs;
using System.Threading.Tasks;

namespace BlogAPI.Services
{
    public interface IUserService
    {
        Task<UserProfileDto> GetProfileAsync(int userId);
    }
}