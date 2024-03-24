using Academy_2024.Dtos;
using Academy_2024.Models;

namespace Academy_2024.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserDto data);

        Task<bool> DeleteAsync(int id);

        Task<List<UserDto>> GetAllAsync();

        Task<UserDto> GetMeAsync(string token);

        Task<UserDto?> GetByIdAsync(int id);

        Task<User?> GetByEmailAsync(string email);

        Task<User?> UpdateAsync(int id, UserDto data);
    }
}
