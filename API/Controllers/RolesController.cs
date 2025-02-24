using API.Dtos;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        #region CreateRole
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto createRoleDto)
        {
            if (string.IsNullOrEmpty(createRoleDto.RoleName))
            {
                return BadRequest("Role name is required");
            }
            var roleExist = await _roleManager.RoleExistsAsync(createRoleDto.RoleName);
            if (roleExist)
            {
                return BadRequest("Role already exists");
            }
            var roleResult = await _roleManager.CreateAsync(new IdentityRole(createRoleDto.RoleName));
            if (roleResult.Succeeded)
            {
                return Ok(new { message = "Role created successfully" });
            }
            return BadRequest("Role creation failed");
        }
        #endregion

        #region GetRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleResponseDto>>> GetRoles()
        {
            var roles = await _roleManager.Roles.Select(r => new RoleResponseDto
            {
                Id = r.Id,
                Name = r.Name,
                TotalUsers = _userManager.GetUsersInRoleAsync(r.Name!).Result.Count
            }).ToListAsync();

            return Ok(roles);
        }
        #endregion

        #region DeleteRole
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound("Role not found");
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role deleted successfully" });
            }
            return BadRequest("Role deletion failed");
        }
        #endregion

        #region AssignRole
        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] RoleAssignDto roleAssignDto)
        {
            var user = await _userManager.FindByIdAsync(roleAssignDto.UserId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var role = await _roleManager.FindByIdAsync(roleAssignDto.RoleId);

            if (role == null)
            {
                return NotFound("Role not found");
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name!);

            if (result.Succeeded)
            {
                return Ok(new { message = "Role assigned successfully" });
            }

            var error = result.Errors.FirstOrDefault();

            return BadRequest(error?.Description); 
        }
        #endregion
    }
}