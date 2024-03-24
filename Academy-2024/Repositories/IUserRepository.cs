using Academy_2024.Dtos;
using Academy_2024.Models;

namespace Academy_2024.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User data);

        Task<bool> DeleteAsync(int id);

        Task<List<User>> GetAllAsync();

        Task<User> GetMeAsync(int id);

        Task<User?> GetByIdAsync(int id);

        Task<User?> GetByEmailAsync(string email);

        Task UpdateAsync();
    }
}