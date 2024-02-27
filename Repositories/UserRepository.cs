using Academy_2024.Models;

namespace Academy_2024.Repositories
{
    public class UserRepository
    {
        private static List<User> Users = new List<User> { 
            new User { Id = 1, FirstName = "Jhon", LastName = "Doe" } 
        };

        public List<User> GetAll() { return Users; }

        public User? GetById(int id)
        {
            foreach (var user in Users) 
            {
                if(user.Id == id) return user;
            }
            return null;
            
        }

        public void Create(User data) {
            Users.Add(data);
        }

        public User? Update(int id,User data) {
            foreach (var user in Users)
            {
                if (user.Id == id)
                {
                    user.FirstName = data.FirstName;
                    user.LastName = data.LastName;
                }
            }
            return null;

        }

        public bool Delete(int id) 
        { 
            foreach (var user in Users) {
                if (user.Id == id)
                {
                    Users.Remove(user);
                    return true;
                }
            }
            return false;
        }
    }
}
