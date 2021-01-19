using PhotoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PhotoAPI.Services
{
    public interface IUserService
    {
        (IEnumerable<User> Users, string Error) GetAllUsers();

        (User user, string Error) GetUser(int id);

        (string Error, int id) AddUser(UserRequest user);

        string UpdateUser(User user);

        string DeleteUser(int id);

        string DeleteAllUsers();
    }
}
