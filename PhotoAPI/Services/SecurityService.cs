using Microsoft.IdentityModel.Tokens;
using PhotoAPI.Model;
using PhotoAPI.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PhotoAPI.Services
{
    public class SecurityService : ISecurityService
    {
        private IUserRepository _userRepository;

        public SecurityService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public (string, AuthUserResponse) AuthUser(AuthUserRequest request)
        {
           (string error, User user) = _userRepository.AuthUser(request); 

            var userIdentity = new ClaimsIdentity();
            userIdentity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()));

            if (user.UserLogin == "admin")
            {
                userIdentity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, "admin"));
            }
            else
            {
                userIdentity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, "user"));
            }

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: DateTime.UtcNow,
                    claims: userIdentity.Claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            AuthUserResponse response = new AuthUserResponse()
            {
                AccessToken = encodedJwt,
                UserId = userIdentity.Name
            };

            return (error, response);
        }
    }
}
