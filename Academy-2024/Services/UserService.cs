using Academy_2024.Dtos;
using Academy_2024.Models;
using Academy_2024.Repositories;
using System.IdentityModel.Tokens.Jwt;
using Bcrypt = BCrypt.Net.BCrypt;

namespace Academy_2024.Services
{
    public class UserService
        : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task CreateAsync(UserDto data)
            => _userRepository.CreateAsync(MapToModel(data));

        public Task<bool> DeleteAsync(int id)
            => _userRepository.DeleteAsync(id);

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(MapToDto).ToList();
        }

        public async Task<UserDto> GetMeAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var sub = jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub);
            int id = Convert.ToInt32(sub.Value.ToString());
            var user = await _userRepository.GetMeAsync(id);

            return MapToDto(user);
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return user != null
                ? MapToDto(user)
                : null;
        }

        public Task<User?> GetByEmailAsync(string email) => _userRepository.GetByEmailAsync(email);

        public async Task<User?> UpdateAsync(int id, UserDto data)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user is not null)
            {
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.Email = data.Email;

                await _userRepository.UpdateAsync();
            }

            return user;
        }

        private static UserDto MapToDto(User user) => new()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = user.Password
        };

        private static User MapToModel(UserDto userDto) => new()
        {
            Id = userDto.Id,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            Password = Bcrypt.EnhancedHashPassword(userDto.Password)
        };
    }
}
