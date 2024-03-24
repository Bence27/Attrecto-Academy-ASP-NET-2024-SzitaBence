using Academy_2024.Data;
using Academy_2024.Dtos;
using Academy_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy_2024.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> GetAllAsync() => _context.Users.ToListAsync();

        public Task<User> GetMeAsync(int id) => _context.Users.FirstOrDefaultAsync(user => user.Id == id)!;
        public Task<User?> GetByIdAsync(int id) => _context.Users.FirstOrDefaultAsync(user => user.Id == id);

        public Task<User?> GetByEmailAsync(string email) => _context.Users.FirstOrDefaultAsync(user => user.Email == email);

        public async Task CreateAsync(User data)
        {
            await _context.Users.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync() => _context.SaveChangesAsync();

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
