using GraduateThesis.Core.Dtos.RoleDtos;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    [Authorize(AuthenticationSchemes ="Bearer",Roles ="admin")]
    public class RolesController : CustomBaseController
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AssignRole(AssignRoleDto dto)
        {
            return CreateAction(await _roleService.AssignRoleAsync(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateAction(await _roleService.GetAllAsync());
        }

        [HttpGet("[action]/{roleId}")]
        public async Task<IActionResult> GetRoleByIdWithUsers(string roleId)
        {
            return CreateAction(await _roleService.GetRoleByIdWithUsersAsync(roleId));
        }

        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetRoleById(string roleId)
        {
            return CreateAction(await _roleService.GetRoleByIdAsync(roleId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto dto)
        {
            return CreateAction(await _roleService.CreateRoleAsync(dto));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto dto)
        {
            return CreateAction(await _roleService.UpdateRoleAsync(dto));
        }

        [HttpDelete("{roleId}")]
        public async Task<IActionResult> RemoveRole(string roleId)
        {
            return CreateAction(await _roleService.RemoveRoleAsync(roleId));
        }
    }
}
