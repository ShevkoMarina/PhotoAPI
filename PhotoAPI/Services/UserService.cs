using PhotoAPI.Model;
using PhotoAPI.Repositories;
using System.Collections.Generic;
using System.Security.Claims;

namespace PhotoAPI.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public (string Error, int id) AddUser(UserRequest user)
        {
            return _userRepository.AddUser(user);
        }

      
        public string DeleteAllUsers()
        {
            return _userRepository.DeleteAllUsers();
        }

        public string DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public (IEnumerable<User> Users, string Error) GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public (User user, string Error) GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        public string UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}
