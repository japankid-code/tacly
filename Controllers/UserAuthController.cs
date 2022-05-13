using backendv3.Models;
using backendv3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace backendv3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase {
        private readonly IUserService _userService;

        public UserAuthController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest model) {
            try {
                return Ok(_userService.LoginUserAsync(model));
            } catch (UnauthorizedAccessException ex) {
                return Unauthorized(ex.Message);
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
