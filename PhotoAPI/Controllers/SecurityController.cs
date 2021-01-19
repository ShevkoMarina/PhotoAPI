using System;
using Microsoft.AspNetCore.Mvc;
using PhotoAPI.Model;
using PhotoAPI.Services;

namespace PhotoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private ISecurityService _accountService;

        public SecurityController(ISecurityService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult AuthUser([FromBody] AuthUserRequest request)
        {
            (string error, AuthUserResponse response) = _accountService.AuthUser(request);

            if (!String.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            return Ok(response);
        }
    }
}
