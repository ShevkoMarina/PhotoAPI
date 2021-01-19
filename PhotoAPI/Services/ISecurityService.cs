using PhotoAPI.Model;
using System.Security.Claims;


namespace PhotoAPI.Services
{
    public interface ISecurityService
    {
        (string, AuthUserResponse) AuthUser(AuthUserRequest request);
    }
}
