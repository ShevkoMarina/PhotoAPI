using PhotoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PhotoAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PhotoDBContext _context;

        public UserRepository(PhotoDBContext context)
        {
            _context = context;
        }

        public (string Error, int id) AddUser(UserRequest user)
        {
            try
            {
                _context.Users.Add(new User { UserLogin = user.UserLogin, UserPassword = user.UserPassword });
                _context.SaveChanges();

                return (null, _context.Users.ToList().Last().Id);
            }
            catch(Exception e)
            {
                return (e.Message, -1);
            }
        }

        // Сделать логины дивидуальными
        public (string, User) AuthUser(AuthUserRequest request)
        {
            try
            {
                var user = _context.Users.ToList()
                    .FirstOrDefault(u => u.UserLogin == request.Login 
                    && u.UserPassword == request.Password);

                if (user != null)
                {
                    return (null, user);
                }

                return ("Wrong password", null);
            }
            catch (Exception e)
            {
                return (e.Message, null);
            }
        }

        public string DeleteAllUsers()
        {
            try
            {
                var adminUser = _context.Users.ToList().Where(u => u.UserLogin == "admin").FirstOrDefault();
                _context.Users.RemoveRange(_context.Users.ToList());
                _context.Users.Add(new User { UserLogin = adminUser.UserLogin, UserPassword = adminUser.UserPassword });
                _context.SaveChanges();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteUser(int id)
        {
            try
            {
                _context.Users.Remove(_context.Users.Find(id));
                _context.SaveChanges();

                return null;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public (IEnumerable<User> Users, string Error) GetAllUsers()
        {
            try
            {
                return (_context.Users.ToList(), null);
            }
            catch(Exception e)
            {
                return (null, e.Message);
            }
        }

        public (User user, string Error) GetUser(int id)
        {
            try
            {
                return (_context.Users.Find(id), null);
            }
            catch(Exception e)
            {
                return (null, e.Message);
            }
        }

        public string UpdateUser(User user)
        {
            try 
            {
                var userOld = _context.Users.Find(user.Id);

                userOld.UserLogin = user.UserLogin;
                userOld.UserPassword = user.UserPassword;

                _context.SaveChanges();

                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
