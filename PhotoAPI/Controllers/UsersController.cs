using System;
using Microsoft.AspNetCore.Mvc;
using PhotoAPI.Model;
using PhotoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PhotoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var result = _userService.GetAllUsers();
            if (result.Error != null)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Users);
        }

       [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
       [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var result = _userService.GetUser(id);
            if (result.user == null)
            {
                return NotFound();
            }

            if (String.IsNullOrEmpty(result.Error))
            {
                return Ok(result.user);
            }

            return BadRequest(result.Error);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("[action]")]
        [HttpPost]
        public IActionResult AddUser([FromBody] UserRequest user)
        {
            var result = _userService.AddUser(user);
            if (String.IsNullOrEmpty(result.Error))
            {
                return Ok(result.id);
            }
            return BadRequest(result.Error);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            var result = _userService.UpdateUser(user);
            if (String.IsNullOrEmpty(result))
            {
                return Ok();
            }
            return BadRequest(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);

            if (String.IsNullOrEmpty(result))
            {
                return Ok();
            }
            return BadRequest(result);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpDelete]
        public IActionResult DeleteAllUsers()
        {
            var result = _userService.DeleteAllUsers();

            if (String.IsNullOrEmpty(result))
            {
                return Ok();
            }
            return BadRequest(result);
        }
    }
}
