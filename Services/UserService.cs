using BlogAPI.Data.Repositories;
using BlogAPI.DTOs;
using System.Threading.Tasks;

namespace BlogAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserProfileDto> GetProfileAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return new UserProfileDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
                RegisteredAt = user.RegisteredAt,
                ArticlesCount = user.Articles?.Count ?? 0
            };
        }
    }
}