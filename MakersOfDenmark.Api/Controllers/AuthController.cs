using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MakersOfDenmark.Api.Resources;
using MakersOfDenmark.Core.Models.Auth;
using MakersOfDenmark.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MakersOfDenmark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        private static readonly string[] scopeRequiredByApi = {"access_as_user"};
        private readonly IAuthService _authService;

        private readonly ILogger<AuthController> _logger;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public AuthController(ILogger<AuthController> logger, IMapper mapper, UserManager<User> userManager,
            RoleManager<Role> roleManager, IAuthService authService)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _authService = authService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserSignUpResource userSignUpResource)
        {
            var user = _mapper.Map<UserSignUpResource, User>(userSignUpResource);

            var userCreateResult = await _userManager.CreateAsync(user, userSignUpResource.Password);

            if (userCreateResult.Succeeded) return Created(string.Empty, string.Empty);

            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(UserLoginResource userLoginResource)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userLoginResource.Email);
            if (user == null) return NotFound("User not found");

            var userSigninResult = await _userManager.CheckPasswordAsync(user, userLoginResource.Password);

            if (userSigninResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(_authService.GenerateJwt(user, roles));
            }

            return BadRequest("Email or password is incorrect.");
        }

        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole(RoleResource roleResource)
        {
            if (string.IsNullOrWhiteSpace(roleResource.Name)) return BadRequest("Role name should be provided");
            if (_roleManager.FindByNameAsync(roleResource.Name) != null) return BadRequest("This role already exists");

            var role = _mapper.Map<RoleResource, Role>(roleResource);

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded) return Created("roles", role);

            return Problem(result.Errors.First().Description, null, 500);
        }


        [HttpGet("GetRoleByName/{roleName}")]
        public async Task<IActionResult> GetRoleByName(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return BadRequest("Role name should be provided");

            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) return BadRequest("This role does not exist");

            return Ok(role.Id);
        }


        [HttpGet("GetRoleById/{roleId}")]
        public async Task<IActionResult> GetRoleById(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId)) return BadRequest("Role Id should be provided");

            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null) return BadRequest("This role does not exists");

            return Ok(role);
        }


        [HttpGet("GetAllRoles")]
        public IEnumerable<Role> GetAllRoles()
        {
            var roles = _roleManager.Roles;
            return roles;
        }


        [HttpGet("GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            var users = _userManager.Users;
            return users;
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId)) return BadRequest("Wrong user id provided.");

            var user = await _userManager.FindByIdAsync(userId);

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
                return Ok();
            return BadRequest();
        }


        [HttpPost("AddRoleToUser/{userId}/{roleId}")]
        public async Task<IActionResult> AddRoleToUser(string userId, string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId) || string.IsNullOrWhiteSpace(userId))
                return BadRequest("User Id and Role Id should be provided");

            var user = await _userManager.FindByIdAsync(userId);
            var role = await _roleManager.FindByIdAsync(roleId);
            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded) return Created(string.Empty, string.Empty);

            return Problem(result.Errors.First().Description, null, 500);
        }
    }
}